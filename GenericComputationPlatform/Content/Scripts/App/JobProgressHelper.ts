class JobProgressHelper {
    static setProgress(progress: number | string, timeRemaining: string, utms: number) {
        const pp = $("#progressBar");

        if (typeof progress === "number")
            progress = `${Math.round(progress * 10000) / 100}%`;

        pp.attr("aria-valuenow", progress).text(progress);
        if (pp.css("width"))
            pp.css("width", progress);

        $("#progressText").text(progress);

        const time = utmsToString(utms);
        $("#updatedTime").text(time);

        if (!timeRemaining)
            return;
        $("#remainTime").prev("span").text("will approximately");
        $("#remainTime").addClass("text-primary").text(timeRemaining);
    }
}