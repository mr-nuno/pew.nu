define([
    'jQuery',
    'underscore',
    'Backbone'
], function ($, _, Backbone, aboutView) {

    var base = Toolbox.Base.extend({
        constructor: function () {

        },
        show: function () {
            $("body").show();
        }
    });

    return base;
});