$(document).ready(function(){
    $("#browse-parts-button").hover(function(event){
        event.preventDefault();
        $(".drop1").show(1);
    },function(){
        $(".drop1").hide(1);
        $(".drop1").hover(function(){
            $(".drop1").slideDown(1);
        },function(){
            $(".drop1").hide(1);
        })
    });
    
})