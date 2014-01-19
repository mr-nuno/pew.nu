define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/history/history.html'
], function ($, _, Backbone, Handlebars, historyTemplate) {

    var view = Backbone.View.extend({
        el: $("#content-container"),
        initialize: function () {
            this.model.bind('change', this.render, this);
        },
        render: function () {
            $.unblockUI();
            var template = Handlebars.compile(historyTemplate);
            this.$el.html(template(this.model.attributes));
        }
    });

    return view;
});