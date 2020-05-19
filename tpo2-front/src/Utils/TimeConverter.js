export function msToHMS(ms) {
    var seconds = ms / 1000;
    var pad = function (num, size) {
            return ('000' + num).slice(size * -1);
        },
        time = parseFloat(seconds).toFixed(3),
        hours = Math.floor(time / 60 / 60),
        minutes = Math.floor(time / 60) % 60,
        seconds1 = Math.floor(time - minutes * 60),
        milliseconds = time.slice(-3);

    return pad(minutes, 2) + ':' + pad(seconds1, 2);
}