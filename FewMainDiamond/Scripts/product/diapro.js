$(function() {
    $(".choose_more").on("click", function () {
        var index = layer.open({
            type: 1,
            title: false,
            closeBtn: 0,
            shift: 0,
            area: ["1200px", "780px"],
            content: $(".gj_search")
        });
        $(".toclose").off('click').on('click', function () {
            layer.close(index);

        });
    });
});