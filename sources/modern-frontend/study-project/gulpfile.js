var     gulp = require('gulp')
    ,   sass = require('gulp-sass')
    ,   include = require('gulp-file-include')
    ,   autoprefizer = require('gulp-autoprefixer')
    ,   clean = require('gulp-clean')
    ,   uncss = require('gulp-uncss')
    ,   imagemin = require('gulp-imagemin')
    ,   cssnano = require('gulp-cssnano')
    ,   uglify = require('gulp-uglify')
    ,   concat = require('gulp-concat')
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
                'source/components/font-awesome/fonts/**/*'
            ], {"base": "source"})
        .pipe(gulp.dest('./dist/'))
})

gulp.task('sass', function() {
    gulp.src('./source/sass/**/*.scss')
        .pipe(sass())
        .pipe(autoprefizer())
        .pipe(cssnano())
        .pipe(gulp.dest('./dist/css/'));
});

gulp.task('html', function () {
    return gulp.src([
            './source/**/*.html', 
            '!./source/inc/**'
        ]).pipe(include())
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

gulp.task('build-js', function () {
    gulp.src('source/javascript/**/*')
        .pipe(concat('app.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./dist/javascript'))
})

gulp.task('default', ['copy'], function () {
    gulp.start('uncss', 'imagemin', 'sass', 'build-js')
})

gulp.task('server', function() {
    browserSync.init({
        server: {
            baseDir: 'dist'
        }
    })

    gulp.watch('./source/sass/**/*.scss', ['sass'])
    gulp.watch('./source/**/*.html', ['html'])
    gulp.watch('./source/javascript/**/*', ['build-js'])
    gulp.watch('./dist/**/*').on('change', browserSync.reload)
});