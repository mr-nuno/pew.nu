define([
    'jQuery',
    'underscore',
    'Backbone'
], function($, _, Backbone) {
    var statsModel = Backbone.Model.extend({
        fetch: function() {

            $.blockUI({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });

            var settings = $.storage().get();
            var stats = [];
            var self = this;
            var gamerTagsLength = this.get("GamerTags").length;
            var count = 0;

            var sortedStats = [gamerTagsLength];

            for(var i = 0; i < gamerTagsLength; i++) {

                $.ajax({
                    url: "http://api.pew.nu/stats/{0}/{1}/{2}".format(settings.Game, settings.Console, this.get("GamerTags")[i]),
                    dataType: 'json',
                    success: function(data) {
                        stats.push(data);
                        count++;

                        if(count == gamerTagsLength) {

                            for(var j = sortedStats; j >= 0; j--) {

                                var gt = self.get("GamerTags")[j];

                                for(var k = 0; k < gamerTagsLength; k++) {

                                    var s = stats[k];
                                    if(s.GamerTag == gt) sortedStats[j] = s;

                                }
                            }


                            self.attributes = sortedStats;
                            self.trigger("change");
                        }
                    }
                });
            }

            return true;
        }
    });
    return statsModel;
});