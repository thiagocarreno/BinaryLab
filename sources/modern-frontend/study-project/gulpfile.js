var gulp = require('gulp')
,   sass = require('gulp-sass');

gulp.task('sass', function() {
    gulp.src('./source/sass/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./source/css/'));
});

gulp.task('listen', function() {
    gulp.watch('./source/sass/**/*.scss', ['sass'])
});