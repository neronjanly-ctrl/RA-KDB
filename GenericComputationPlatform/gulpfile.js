/// <binding ProjectOpened='watch' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

// ReSharper disable UndeclaredGlobalVariableUsing
const gulp = require("gulp");
const concat = require("gulp-concat");
const rename = require("gulp-rename");
const csso = require("gulp-csso");
const sass = require("gulp-sass")(require("sass"));
const uglify = require("gulp-uglify");
const ts = require("gulp-typescript");
const sourcemaps = require("gulp-sourcemaps");

// pipeline calls between init() and write() must have support for gulp-sourcemaps
// https://github.com/gulp-sourcemaps/gulp-sourcemaps/wiki/Plugins-with-gulp-sourcemaps-support

const paths = {
    styles: {
        src: "./Content/Styles/",
        dest: "./wwwroot/css",
        file: "site.css"
    },
    scripts: {
        src: "./Content/Scripts/",
        dest: "./wwwroot/js",
        file: "site.js"
    },
    libraries: {
        src: "./node_modules/",
        dest: "./wwwroot/lib",
        pkgs: {
            // filter syntax see https://github.com/isaacs/node-glob#glob-primer
            "jquery": "dist/*",
            "jquery-mousewheel": "*.js",
            "bootstrap": "dist/**/*",
            "@fortawesome": "fontawesome-free/+(css|webfonts)/*",
            "popper.js": "dist/umd/*",
            "@microsoft/signalr": "dist/browser/*",
            "ngl": "dist/*",
            "datatables.net": "js/*",
            "datatables.net-bs4": "+(css|js)/*",
            "jsme": "jsme/**/*",
        }
    }
};

// Use npm instead of Bower for client js libraries
// https://wildermuth.com/2017/11/19/ASP-NET-Core-2-0-and-the-End-of-Bower


let tasks = [];
for (let pkg in paths.libraries.pkgs) {
    const filter = paths.libraries.pkgs[pkg];
    const pkgsrc = `${paths.libraries.src}${pkg}/${filter}`;
    const pkgdest = `${paths.libraries.dest}/${pkg}`;
    tasks.push(() => gulp.src(pkgsrc).pipe(gulp.dest(pkgdest)));
}

gulp.task("buildLibs", gulp
    .parallel(tasks)
);

gulp.task("buildScss", () => gulp
    .src(paths.styles.src + "*.scss") // prepare all files
    .pipe(sourcemaps.init()) // read source code for mappings
    .pipe(concat(paths.styles.file)) // merge *.scss to a single file
    .pipe(sass()) // transpile from sass to css
    .pipe(sourcemaps.write(undefined, { includeContent: false })) // append sourcemaps tag to output
    .pipe(gulp.dest(paths.styles.dest)) // write css file to disk
    .pipe(csso()) // minify css content
    .pipe(rename({ suffix: ".min" })) // rename to .min.css
    .pipe(sourcemaps.write(".", { includeContent: false })) // write .min.css.map file
    .pipe(gulp.dest(paths.styles.dest)) // write .min.css file
);

const tsconfig = paths.scripts.src + "tsconfig.json";
const tsproj = ts.createProject(tsconfig, { outFile: paths.scripts.file });

gulp.task("buildTs", () => tsproj
    .src() // prepare all files
    .pipe(sourcemaps.init()) // read source code for mappings
    .pipe(tsproj()) // transpile typescript files as a project
    .js // get result javascript code
    .pipe(sourcemaps.write(undefined, { includeContent: false })) // append sourcemaps tag to output
    .pipe(gulp.dest(paths.scripts.dest)) // write js file to disk
    .pipe(uglify()) // minify js content
    .pipe(rename({ suffix: ".min" })) // rename to .min.js
    .pipe(sourcemaps.write(".", { includeContent: false })) // write .min.js.map file
    .pipe(gulp.dest(paths.scripts.dest)) // write .min.js file
);

gulp.task("watch", () => {
    gulp.watch(paths.styles.src + "**/*.scss", gulp.parallel("buildScss"));
    gulp.watch(paths.scripts.src + "**/*.ts", gulp.parallel("buildTs"));
});

// ReSharper restore UndeclaredGlobalVariableUsing