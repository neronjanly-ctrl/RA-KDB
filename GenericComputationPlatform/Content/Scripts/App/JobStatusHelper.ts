class JobStatusHelper {
    // string resources
    private static strRes = new Map<string, string[]>([
        ["Created", [
            "info",
            "The job was enqueued and is awaiting computation resource for running.",
            "Last updated",
            "The job was created at {0} and is awaiting computation resource for running."
        ]],
        ["Initializing", [
            "info",
            "The job is being initialized and will start to run soon.",
            "Last updated",
            "The job is being initialized since {0} and will start to run soon."
        ]],
        ["Failed", [
            "danger",
            "The job was finished with errors. The most common case of failure is that the input compound is too large to fit into a target pocket. Please check the output page for the specific failed entries.",
            "Last updated",
            "The job was finished with errors at {0}. The most common case of failure is that the input compound is too large to fit into a target pocket. Please contact administrator for more details."
        ]],
        ["Finished", [
            "success",
            "The job was finished successfully. You can see the output page for detailed result.",
            "Finished",
            "The job was finished at {0}."
        ]],
        ["Running", [
            "primary",
            "The job is being computed and <span>can</span> take <span id='remainTime'>a few minutes up to couple hours</span> to complete.",
            "Last updated",
            "The job is running and so far <span class='text-primary' id='progressText'>0%</span> has been finished. Last updated at <span id='updatedTime'>{0}</span>."
        ]]
    ]);

    static setStatus(status: string, utms: number) {
        // get profile for current status
        const profile = JobStatusHelper.strRes.get(status);
        if (profile === undefined)
            return;

        const time = utmsToString(utms);

        // status text
        JobStatusHelper.strRes.forEach(arr => $("#statusText").removeClass(`text-${arr[0]}`));
        $("#statusText").text(status).addClass(`text-${profile[0]}`);
        $("#statusDesc").html(profile[1]);
        $("#statusDesc2").html(profile[3].replace(/\{0\}/, time));

        // updated time
        $("#updatedTimeText").text(profile[2]);
        $("#updatedTime").text(time);

        // progress bar
        JobStatusHelper.strRes.forEach(arr => $("#progressBar").removeClass(`bg-${arr[0]}`));
        $("#progressBar").addClass(`bg-${profile[0]}`);
        if (status === "Running")
            $("#progressBar").addClass("progress-bar-animated");
        else
            $("#progressBar").removeClass("progress-bar-animated");
    }
}