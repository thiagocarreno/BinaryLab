var     gulp = require('gulp')
    ,   sass = require('gulp-sass')
    ,   include = require('gulp-file-include')
    ,   autoprefizer = require('gulp-autoprefixer')
    ,   clean = require('gulp-clean')
    ,   uncss = require('gulp-uncss')
    ,   imagemin = require('gulp-imagemin')
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
                'source/javascript/**/*'
            ], {"base": "source"})
        .pipe(gulp.dest('./dist/'))
})

gulp.task('sass', function() {
    gulp.src('./source/sass/**/*.scss')
        .pipe(sass())
        .pipe(autoprefizer())
        .pipe(gulp.dest('./dist/css/'));
});

gulp.task('html', function () {
    return gulp.src('./source/**/*.html')
        .pipe(include())
        .pipe(gulp.dest('./dist/'))
});

gulp.task('uncss', ['html'], function () {
    return gulp.src('./dist/components/**/*.css')
        .pipe(uncss(
            {
                html: ['./dist/*.html']
            }
        ))
        .pipe(gulp.dest('./dist/components/'))
})

gulp.task('imagemin', function () {
    return gulp.src('./source/imagens/**/*')
        .pipe(imagemin())
        .pipe(gulp.dest('./dist/imagens/'))
})

gulp.task('server', ['uncss', 'imagemin', 'sass', 'copy'], function() {
    browserSync.init({
        server: {
            baseDir: 'dist'
        }
    })

    gulp.watch('./source/sass/**/*.scss', ['sass'])
    gulp.watch('./source/**/*.html', ['html'])
    gulp.watch('./dist/**/*').on('change', browserSync.reload)
});