
function gwiazdki(x) {
    star = ('<span class="glyphicon glyphicon-star"></span>');
    star2 = ('<span class="glyphicon glyphicon-star-empty"></span>');
    star3 = ('<span class="glyphicon glyphicon-star half"></span>');

    z = (Math.round(x * 2) / 2).toFixed(1);
    y = Math.floor(x);

    for (n = 0; n < y; n++) {
        document.write(star);
    }
    k = x % 1;
    if (k > 0.3 && k < 0.7) {
        document.write(star3);
    }

    for (n = x + 1; n < 5; n++) {
        document.write(star2);
    }
}