module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');

    // configure plugins
    grunt.initConfig({
        uglify: {
            my_target: {
                files: { 'wwwroot/Assets/js/App.js': ['Assets/js/App.js', 'Assets/js/**/*.js'] }
            }
        },

        watch: {
            scripts: {
                files: ['Assets/js/**/*.js'],
                tasks: ['uglify']
            }
        }
    });

    // define tasks
    grunt.registerTask('default', ['uglify', 'watch']);
};