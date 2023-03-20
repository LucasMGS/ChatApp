using Chat.Application.Abstractions;
using Chat.Core;
using Chat.Domain.Entities;
using Chat.Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace Chat.Application.Commands.CreateUser
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        public IUserRepository _userRepository{ get; set; }
        private ILogger<CreateUserHandler> _logger;
        private UserManager<IdentityUser<Guid>> _userManager;
        public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger, UserManager<IdentityUser<Guid>> userManager)
        {
            _userRepository = userRepository;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Result> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await CreateUser(command, cancellationToken);

                if (!result.IsSuccess) return result;

                await _userRepository.CommitTransactionAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating user {UserEmail}..", command.Email);
                await _userRepository.RollbackTransactionAsync(cancellationToken);

                return Result.WithError(new Error("Error creating user"));
            }
            
        }

        private async Task<Result> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var identityUser = new IdentityUser<Guid>()
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                UserName = command.Name,
            };
            var result = await _userManager.CreateAsync(identityUser, command.Password);
            if (!result.Succeeded)
            {
                await _userRepository.RollbackTransactionAsync(cancellationToken);
                return LogAndReturnUserManagerErrors(command, result);
            }

            var user = new User(command.Name, identityUser.Id);
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync(cancellationToken);
            return Result.Success();

        }

        private Result LogAndReturnUserManagerErrors(CreateUserCommand command, IdentityResult result)
        {
           var errors = result.Errors
          .Select(e => new Error(e.Description))
          .ToList();

           _logger.LogInformation("Error creating IdentityUser {UserEmail} - {@Errors}", command.Email, errors);

           return Result.WithErrors(errors);
        }
    }
}
