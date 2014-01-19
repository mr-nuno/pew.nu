define([
    'jQuery',
    'underscore',
    'Backbone',
    'application/views/leaderBoardView',
    'application/models/leaderBoardModel',
    'application/controllers/base'
], function($, _, Backbone, leaderBoardView, leaderBoardModel, base) {

    var controller = base.extend({
        constructor: function() {

        },
        show: function() {
            this.execute();
        },
        execute: function() {
            var model = new leaderBoardModel();
            var view = new leaderBoardView({
                model: model
            });

            model.fetch();
            controller.__super__.show();
        }
    });

    return controller;
});