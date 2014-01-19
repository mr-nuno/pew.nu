define([
    'jQuery',
    'application/router',
    'application/common/menu',
    'application/common/operator',
    'application/common/message'
], function($, Router){
    var initialize = function() {

        Router.initialize();
        $.operator();
        $.menu();
        $.message();
        
        //tooltips
        $('.ui-tooltip').tooltip({ placement: "bottom" });
        
        //popovers
        $(".ui-popover").popover();

        //setup push support
        var connection = $.connection();
        connection.url = 'http://api.pew.nu/push';
        connection.received(function (data) {
            if (data) $.operator().publish("match-info-received", data);
        });

        if ($.browser.msie) connection.start();
        else connection.start({ jsonp: true });

    };

    return {
        initialize: initialize
        
    };
});
