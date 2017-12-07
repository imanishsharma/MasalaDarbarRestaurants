$(document).ready(function(){

            $('.filter').hide('3000');
        
    $(".filter-button").click(function(){
        var value = $(this).attr('data-filter');

        
            $(".filter").not('.'+value).hide('3000');
            $('.filter').filter('.'+value).show('3000');

        
    });

    if ($(".filter-button").removeClass("active")) {
$(this).removeClass("active");
}
$(this).addClass("active");

});
