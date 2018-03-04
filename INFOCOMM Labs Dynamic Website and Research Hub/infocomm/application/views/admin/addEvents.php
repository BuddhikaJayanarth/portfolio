  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Events
      </h1>
    </section>
    <!-- Main content -->
    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Add Event</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form id="addEventForm" enctype="multipart/form-data">
              <div class="box-body">
              	
              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                
                <div class="form-group">
                  <input type="text" class="form-control" name="name" placeholder="Event Name" required>
                </div>
                
                <div class="form-group">
	                <div class="input-group date">
	                  <div class="input-group-addon">
	                    <i class="fa fa-calendar"></i>
	                  </div>
	                  <input type="text" class="form-control pull-right" name="date" id="datepicker" placeholder="Date" required>
	                </div>
	            </div>

              	<div class="bootstrap-timepicker">
	                <div class="form-group">
	                  <div class="input-group">
	                  	<div class="input-group-addon">
	                      <i class="fa fa-clock-o"></i>
	                    </div>
	                    <input type="text" class="form-control timepicker" name="time" placeholder="Time" required>
	                  </div>
	                </div>
	            </div>
              	<div class="form-group">
                  <div class="input-group">
                    <input type="number" class="form-control" name="duration" placeholder="Duration" required>

                    <div class="input-group-addon">
                      h
                    </div>
                  </div>
                </div>
                <div class="form-group">
                  <div class="input-group">
                  	<div class="input-group-addon">
                      <i class="fa fa-map-marker"></i>
                    </div>
                    <input type="text" class="form-control" name="location" placeholder="Location" required>
                  </div>
                </div>
              	<div class="form-group">
					<textarea id="description" name="description" rows="8" cols="150" placeholder="Description"></textarea>
                </div>
                <div class="form-group">
                  <label>Add Image</label>
                  <input type="file" id="img" name="img">

                  <p class="help-block">Upload an image less than 2 MB and dimensions 400x300 or it will be resized accordingly.</p>
                </div>
                <br />
				  <input type="hidden" id="imageID" name="imageID">
              </div>
              <!-- /.box-body -->
              <div class="box-footer">
                <button type="submit" class="btn btn-success">Add Event</button>
              </div>
            </form>
          </div>
          <!-- /.box -->
        </div>
        <!--/.col (right) -->
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
<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<!-- bootstrap time picker -->
<script src="<?php echo base_url(); ?>plugins/timepicker/bootstrap-timepicker.min.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- CK Editor -->
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>
<!-- page script -->
<script>
	$(function () {
	      
    	//Date picker
    	$('#datepicker').datepicker({
      	autoclose: true
    	});

    	//Timepicker
    	$(".timepicker").timepicker({
			showInputs: false
		});
		
		//initializes the CK editor instance
		CKEDITOR.replace('description');
		
		var imageID = null;
		
		//add event
		$(document).on('submit', "#addEventForm",function(e) {
			
			e.preventDefault();
			
			$.ajax({
				url: "events/add",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
					if(result == 'There was an error adding this event. Please try again')
						alert(result);
					else
					{
						//uploads image
						imageID = result;
						$("#imageID").val(imageID);
						//creates form object 
						var form = $('#addEventForm')[0];
						var formData = new FormData(form);
						
						$.ajax({
							
							url: "addEvent/uploadImage",
							type: "POST",
							data: formData,
							contentType: false,
							cache: false,
							processData: false,
							success: function(result, status){
								if(result == "Success")
								{
									alert("Added Successfully!");
									window.location = $("#baseURL").val() + "admin/events";
								}
								else
								{
									window.location = $("#baseURL").val() + "admin/events";
								}
							}					
						});
					}					
				}					
			});
		});
	});
</script>
