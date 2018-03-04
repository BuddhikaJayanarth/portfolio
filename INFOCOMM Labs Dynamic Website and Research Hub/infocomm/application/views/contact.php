<?php
//queries the databse for the contact details
$query = $this->db->get("contact");
$output = $query->result();
$o1;
foreach($output as $o){
$o1 = $o;	
}

?>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">

    <!-- Main content -->
    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-success">
            <div class="box-header with-border">
              <h3 class="box-title"><?php echo $o1->contactheader;?></h3>
              <h6><?php echo $o1->contactbody;?></h6>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form id="contactForm" role="form" enctype="multipart/form-data">
              <div class="box-body">
                <input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <div class="form-group">
                  <input type="text" class="form-control" name="name" placeholder="Name" required="required">
                </div>
                
                <div class="form-group">
	                  <div class="input-group">
	                    <div class="input-group-addon">
	                      <i class="fa fa-envelope"></i>
	                    </div>
	                    <input type="email" class="form-control" name="email" placeholder="Email" required="required">
	                  </div>
	                </div>
	                
	                <div class="form-group">
	                  <div class="input-group">
	                    <div class="input-group-addon">
	                      <i class="fa fa-phone"></i>
	                    </div>
	                    <input type="tel" class="form-control" name="contact" placeholder="Contact">
	                  </div>
	                </div>
                
              	<div class="form-group">
                  <textarea class="form-control" rows="5" name="message" placeholder="Your message here ..." required="required"></textarea>
                </div>
                                                
              </div>
              
              <!-- /.box-body -->

              <div class="box-footer">
                <button type="reset" class="btn btn-success">Clear</button>
                <button type="submit" class="btn btn-success">Submit</button>
              </div>
            </form>
          </div>
          <!-- /.box -->
        </div>
        <!--/.col (right) -->

        <!-- right column -->
        <div class="col-md-6">

        <div id="googleMap" style="width:100%;height:400px;"></div>

        <script>
          function myMap() {
			
			var x = <?php echo json_encode($o1->xcoordinate, JSON_HEX_TAG); ?>;
			var y = <?php echo json_encode($o1->ycoordinate, JSON_HEX_TAG); ?>;  
			  
            var mapProp= {
            center:new google.maps.LatLng(x,y),
            zoom:15,
          };
          var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);
          }
          </script>

        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC0mbpOLT5Y6HXMjcKifs_1cCge-Ik3wT8&callback=myMap"></script>

        </div>


      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->

    
  </div>
  <!-- /.content-wrapper -->
  
<!-- includes footer -->

<!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- SlimScroll -->
<script src="<?php echo base_url(); ?>plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="<?php echo base_url(); ?>plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url(); ?>dist/js/demo.js"></script>
<!-- page script -->
<script>
  $(function () {
    
    //submit form
	$(document).on('submit', "#contactForm",function(e) {
		
		e.preventDefault();
		
		$.ajax({
			type: "POST",
			url: "contact/submit",
			data: new FormData(this),
			processData: false,
			cache: false,
			contentType: false,				
			success: function(result, status) {
			        alert(result);
			        window.location = $("#baseURL").val() + "contact";
			}
		});
	
	});
  });
  
  
</script>
