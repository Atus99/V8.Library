

//var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:52045/NotificationHub").withAutomaticReconnect().build();
//"http://localhost:52045/NotificationHub?name=1234"

// NotificationHub
var notifyServerUrl = $("#LayoutNotifyUrl").val() + "/NotificationHub?userid=" + $("#LayoutUserId").val();
var connection = new signalR.HubConnectionBuilder().withUrl(notifyServerUrl).build();

connection.on("LoadNotifyByUserId", function (userId) {
    //Todo: hàm này được gọi từ server, thực hiện việc call ajax để load ra notification của người dùng
    Notification.LoadListNotification();
});

connection.start().then(function () {
    //Todo: nothing
}).catch(function (err) {
    return console.error(err.toString());
});

//// CommonHub
//var loadServerUrl = $("#LayoutNotifyUrl").val() + "/CommonHub?userid=" + $("#LayoutUserId").val();
//var conn = new signalR.HubConnectionBuilder().withUrl(loadServerUrl).build();

//conn.on("LoadPageByUserId", function (userId) {
//    window.location.reload();
//});

//conn.start().then(function () {
//}).catch(function (err) {
//    return console.error(err.toString());
//});

var Notification = {
    ReadNotify: function () {
        $(".unread").on('click', function () {
            const self = $(this);
            const id = self.data("id");
            $.ajax({
                async: false,
                data: {},
                method: "POST",
                url: "/Home/ReadNotification?id=" + id
            }).done(function (data) {
                // If successful
                //let total = parseInt($("#totalUnreadNotification").text());
                //$("#totalUnreadNotification").text(total > 0 ? total - 1 : 0);
                //self.removeClass("unread");
                //self.off('mouseover'); //.unbind() has been deprecated
            }).fail(function (jqXHR, textStatus, errorThrown) {
                // If fail
                alert(textStatus + ': ' + errorThrown);
                if (typeof (errCallback) === "function") {
                    errCallback();
                }
            });
        });
        $("#markAllRead").on("click", function () {
            $.ajax({
                async: false,
                data: {},
                method: "POST",
                url: "/Home/ReadAllNotification"
            }).done(function (data) {
                // If successful
                $("#totalUnreadNotification").text(0);
                $(".unread").removeClass("unread");
                $(".unread").off('mouseover'); //.unbind() has been deprecated
                $('#headerNotification').find("*").removeClass("text-blue");
                $('#headerNotification').find("i").removeClass("fas fa-fw fa-circle");
            }).fail(function (jqXHR, textStatus, errorThrown) {
                // If fail
                alert(textStatus + ': ' + errorThrown);
                if (typeof (errCallback) === "function") {
                    errCallback();
                }
            });
        });
    },
    LoadListNotification: function () {
        $.ajax({
            async: false,
            data: { pageIndex: 1, pageSize: 30 },
            method: "POST",
            url: "/Home/HeaderNotification"
        }).done(function (data) {
            // If successful
            $("#notification").html(data);
            Notification.ReadNotify();
        }).fail(function (jqXHR, textStatus, errorThrown) {
            // If fail
            alert(textStatus + ': ' + errorThrown);
            if (typeof (errCallback) === "function") {
                errCallback();
            }
        });
    },
}

