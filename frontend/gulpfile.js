var gulp = require("gulp");
var useref = require("gulp-useref");
var uglify = require("gulp-uglify");
var cssnano = require("gulp-cssnano");
var gulpIf = require("gulp-if");

var browserSync = require("browser-sync").create();

gulp.task("useref", function () {
  return gulp.src(["index.html"])
      .pipe(useref())
      .pipe(gulpIf("*.js", uglify()))
      .pipe(gulpIf("*.css", cssnano()))
      .pipe(gulp.dest("dist"));
});

gulp.task("serverApp", function () {
    browserSync.init({
        server: {
            baseDir: ".",index: "index.html"
        }
    });
});

gulp.task("serverDist", function () {
    browserSync.init({
        server: {
            baseDir: "dist",index: "index.html"
        }
    });
});