var     gulp = require('gulp')
    ,   sass = require('gulp-sass')
    ,   browserSync = require('browser-sync');

gulp.task('sass', function() {
    gulp.src('./source/sass/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./source/css/'));
});

gulp.task('server', function() {
    browserSync.init({
        server: {
            baseDir: 'source'
        }
    })

    gulp.watch('./source/sass/**/*.scss', ['sass'])
    gulp.watch('./source/**/*').on('change', browserSync.reload)
});