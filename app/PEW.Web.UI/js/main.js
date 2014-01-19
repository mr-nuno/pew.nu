require.config({
    shim: {
        'backbone': {
            deps: ['underscore', 'jQuery'],
            exports: 'Backbone'
        },
        'blockUI': {
            deps: ['jQuery'],
            exports: 'blockUI'
        },
        'cookie': {
            deps: ['jQuery'],
            exports: 'cookie'
        },
        'storage': {
            deps: ['jQuery'],
            exports: 'storage'
        },
        'backboneToolbox': {
            deps: ['Backbone'],
            exports: 'backboneToolbox'
        },
        'signalR': {
            deps: ['jQuery'],
            exports: 'signalR'
        }

    },
    paths:{
        jQuery:'libs/jquery/jquery-loader',
        underscore:'libs/underscore/underscore-loader',
        Backbone:'libs/backbone/backbone-loader',
        text:'libs/require/text-2.0',
        pubsubz: 'libs/pubsubz/pubsubz',
        bootstrapTwitter: 'libs/bootstrap-twitter/bootstrap.min',
        handlebars: 'libs/handlebars/handlebars-loader',
        blockUI: 'libs/jquery-plugins/jquery.blockUI',
        cookie: 'libs/jquery-plugins/jquery.cookie',
        json2: 'libs/json2/json2',
        storage: 'application/common/storage',
        backboneToolbox: 'libs/backbone-toolbox/backbone-toolbox',
        signalR: 'libs/signalr/jquery.signalR-0.5.2.min'
    }
});

require(['jQuery', 'blockUI', 'cookie', 'json2', 'storage', 'backboneToolbox', 'signalR'],
    function ($) {

        //string format
        String.prototype.format = String.prototype.f = function () {
            var s = this, i = arguments.length;
            while (i--) { s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]); }
            return s;
        };

        //string format
        String.prototype.equals = String.prototype.eq = function (str) {
            return s === str;
        };

        //activate cors support
        $.support.cors = true;

        //init app
        require(['app', 'pubsubz', 'bootstrapTwitter', 'signalR'], function(app) {
            app.initialize();
        });
    });