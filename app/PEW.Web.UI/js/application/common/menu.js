(function ($)
{
    $.extend({
        menu: function ()
        {
            var _base = this;

            var deselectAll = function() {

            };

            var _init = function ()
            {
                $("#nav-stats-button").live("click", function() {
                    deselectAll();
  
                });

                $("#nav-games-button").live("click", function() {
                    deselectAll();
                });

                $("#nav-howhot-button").live("click", function() {
                    deselectAll();
                });

            };

            _init();

            return _base;
        }
    });
})(jQuery); 