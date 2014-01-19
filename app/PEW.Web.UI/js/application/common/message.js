(function ($)
{
    $.extend({
        message: function ()
        {
            var _base = this;
            var _autoHide = true;

            var showMessage = function(type, message, autoHide) {
                var container = $("#" + type + "-container");
                container.find(".message").html(message);

                var f = function() {
                    container.hide();
                };

                container.show();

                if (autoHide) setTimeout(f, 5000);

                container.find("button.close").live("click", function() {
                    f();
                });

            };

            var showError = function(message, autoHide) {
                showMessage("error", message, autoHide);
            };
            
            var showInformation = function(message, autoHide) {
                showMessage("info", message, autoHide);
            };

            var showSuccess = function (message, autoHide) {
                showMessage("success", message, autoHide);
            };

            var render = function (data)
            {
                switch (data.type)
                {
                    case "error":
                        showError(data.message, _autoHide);
                        break;
                    case "info":
                        showInformation(data.message, _autoHide);
                        break;
                    case "success":
                        showSuccess(data.message, _autoHide);
                        break;
                };
            };

            var _init = function ()
            {
                $.operator().subscribe("send-message", function (type, data)
                {
                    render(data);
                });
                
            };

            _init();

            return _base;
        }
    });
})(jQuery); 