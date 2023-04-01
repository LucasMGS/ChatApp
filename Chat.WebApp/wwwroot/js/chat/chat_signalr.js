$(function () {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/Chat/Hub")
        .withAutomaticReconnect()
        .build();

    connection.on("ReceiveMessage", function (message) {
        console.log(message.userName + " says " + message);
        var messageHtml =
                '<div class="chat-message-header">' +
                '<div class="message-header">' +
                    '<p class="chat-message-sender">' + message.userName + ':</p>' +
                    '<label class="chat-message-time">' + message.sentAtString + '</label>' +
                '</div>'+
                    '<p class="chat-message-text">' + message.message + '</p>' +         
            '</div>';

        $(".chat-messages").append(messageHtml);
    });
    

    //var message = "Hello world"
    //connection.invoke("SendMessage", message).catch(function (err) {
    //    return console.error(err.toString());
    //})

    connection.start().then(function () {
        let chatId = $('#chat-id').val();
        connection.invoke("JoinChat", chatId)
            .catch(function (err) {
                return console.error(err.toString());
            });
    })

    $("#sendMessageform").submit(function (e) {
        e.preventDefault();

        let chatRoomId = $('#chat-id').val();
        let message = $("#message-area").val();
        console.log(message)

        $("#message-area").val("")

        connection.invoke("SendMessage", {
            chatRoomId,
            message
        }).catch((err) => console.error(err.toString()));
    })
});

