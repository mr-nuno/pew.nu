define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/about/about.html'
], function ($, _, Backbone, Handlebars, aboutTemplate) {

    var view = Backbone.View.extend({
        el: $("#content-container"),
        initialize: function () {
            this.render();
        },
        render: function () {
            var template = Handlebars.compile(aboutTemplate);
            this.$el.html(template());
        }
    });

    return view;
});