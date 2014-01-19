define([
    'jQuery',
    'underscore',
    'Backbone',
    'handlebars',
    'text!templates/leaderboard/leaderboard.html'
], function($, _, Backbone, Handlebars, leaderBoardTemplate) {

    var view = Backbone.View.extend({
        el: $("#content-container"),
        initialize: function() {
            this.model.bind('change', this.render, this);
        },
        render: function() {
            $.unblockUI();
            var template = Handlebars.compile(leaderBoardTemplate);
            this.$el.html(template(this.model.attributes));
        }
    });

    return view;
});