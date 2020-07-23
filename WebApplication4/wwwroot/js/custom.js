$(document).ready(function () {
  
    $("#email").keyup(function(){
        if($('#email').val() != "")
        {
            $("#lcField").removeClass('disabled');
            $("#lcSubmit").removeClass('disabled');
            $("#lcSubmit").removeAttr("disabled");
        }
        else
        {
            $("#lcField").addClass('disabled');
            $("#lcSubmit").addClass('disabled');
            $("#lcSubmit").addAttr("disabled");
        }
  });
 
  
  $("#lcSubmit").click(function(){
      
    if($('#lcForm')[0].checkValidity())
    {
        event.preventDefault();
        $(".contractModal").modal({
      onApprove: function() {
        $('#lcForm').submit();
      }
    }).modal('show');
    }

  });  

    $("#acSubmit").click(function () {

        if ($('#acForm')[0].checkValidity()) {

            if (totalScore < 14) {
                $("#rfErrorP").removeClass();
                $("#rfErrorP").addClass("error required field");
                $("#rfErrorTxt").css("display", "inline-block");
            }
            else {
                var pass = $('input[name=password]').val();
                var repass = $('input[name=password_confirmation]').val();
                if (pass != repass) {
                    $("#rfErrorPC").removeClass();
                    $("#rfErrorPC").addClass("error required field");
                    $("#rfErrorMatchTxt").css("display", "inline-block");
                }
                else {
                    $('#acForm').submit();
                }


            }

        }

    });
    
});

