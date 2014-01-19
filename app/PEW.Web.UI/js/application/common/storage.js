(function ($)
{
    $.extend({
        storage: function ()
        {
            var _base = this;
            var _cookieName = "pew.stats.client.session";
            var _default = {
                Id : null,
                LastVisit: new Date(),
                GamerTag: "?",
                Game: "",
                Console: "ps3",
                Friends: [],
                FirstName: "",
                LastName: "",
                Email: "",
                Gravatar: "",
                HistoryCount: 15,
                Theme: "default"
            };

            var _profileRequest = function (data, type) {

                

            };

            var _init = function ()
            {
                if ($.cookie(_cookieName) == null) $.cookie(_cookieName, JSON.stringify(_default), { expires: 365, path: '/' });
            };
            _base.default = function() {
                return _default;
            };

            _base.update = function (data)
            {
                $.cookie(_cookieName, JSON.stringify(data), { expires: 365, path: '/' });
            };

            _base.destroy = function ()
            {
                $.cookie(_cookieName, null);
            };

            _base.get = function ()
            {
                var s = $.parseJSON($.cookie(_cookieName));
                return s;
                $.ajax({
                    url: "http://api.pew.nu/profile/{0}".format(s.GamerTag),
                    dataType: 'json',
                    async: false,
                    type: "GET",
                    data: null,
                    success: function (response) {
                        return response;
                    }
                });
            };

            _init();

            return _base;
        }
    });
})(jQuery); 