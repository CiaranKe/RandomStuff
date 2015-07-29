function initPlayerControls()
{
    var video = document.getElementById('videoplayer');

    function playVideo(evt)
    {
        if (video.paused)
        {
            video.play();
            evt.target.textContent = "Pause";
        }
        else
        {
            video.pause();
            evt.target.textContent = "Play";
        }
    }

    function seek(numSecs)
    {
        try
        {
            if (numSecs == 0)
            {
                video.currentTime = numSecs;
            }
            else
            {
                video.currentTime += numSecs;
            }
        }
        catch (err)
        {
            displayError("Something's gone wrong :(")
        }
    }

    document.getElementById('playButton').addEventListener('click', playVideo, false);
    document.getElementById('backButton').addEventListener('click', function() {seek(-5)}, false);
    document.getElementById('forwardButton').addEventListener('click', function() {seek(5)}, false);
    document.getElementById('slowerButton').addEventListener('click', function() {video.playbackRate -= .25}, false);
    document.getElementById('fasterButton').addEventListener('click', function() {{video.playbackRate += .25}}, false);
    document.getElementById('muteButton').addEventListener('click', function(){video.muted = !(video.muted)}, false);

}