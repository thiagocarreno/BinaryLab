var     gulp = require('gulp')
    ,   sass = require('gulp-sass')
    ,   include = require('gulp-file-include')
    ,   clean = require('gulp-clean')
    ,   browserSync = require('browser-sync').create();

gulp.task('clean', function () {
    return gulp.src('./dist')
        .pipe(clean());
})

gulp.task('copy', ['clean'], function () {
    gulp.src([  'source/components/bootstrap/css/**/*',
                'source/components/bootstrap/fonts/**/*',
                'source/components/bootstrap/js/**/*',
                'source/components/font-awesome/css/**/*',
                'source/components/font-awesome/fonts/**/*',
                'source/css/**/*',
                'source/javascript/**/*',
                'source/imagens/**/*'
            ], {"base": "source"})
        .pipe(gulp.dest('./dist/'))
})

gulp.task('sass', function() {
    gulp.src('./source/sass/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./source/css/'));
});

gulp.task('html', ['copy'], function () {
    gulp.src('./source/**/*.html')
        .pipe(include())
        .pipe(gulp.dest('./dist/'))
});

gulp.task('server', ['sass', 'html'], function() {
    browserSync.init({
        server: {
            baseDir: 'dist'
        }
    })

    gulp.watch('./source/sass/**/*.scss', ['sass'])
    gulp.watch('./source/**/*.html', ['html'])
    gulp.watch('./dist/**/*').on('change', browserSync.reload)
});