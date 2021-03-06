﻿$('.ui.accordion')
    .accordion();

$('.ui.dropdown')
    .dropdown();

$('.special.cards .image').dimmer({
    on: 'hover'
});

$('.menu .item')
    .tab();

$('.masthead')
    .visibility({
        once: false,
        onBottomPassed: function () {
            $('.fixed.menu').transition('fade in');
        },
        onBottomPassedReverse: function () {
            $('.fixed.menu').transition('fade out');
        }
    })
    ;

var content = [
    { title: 'Andorra' },
    { title: 'United Arab Emirates' },
    { title: 'Afghanistan' },
    { title: 'Antigua' },
    { title: 'Anguilla' }];

$('.ui.search')
    .search({
        source: content
    });