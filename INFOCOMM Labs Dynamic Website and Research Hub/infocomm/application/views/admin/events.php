<?php
$this->db->order_by('date', 'DESC');
$query = $this->db->get('events');
$eventList = $query->result();
?> 


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
        <div class="col-xs-12">
          <div class="box">
            <!-- /.box-header -->
            <div class="box-body"><div class="table table-responsive">
              <table class="eventTable table table-bordered table-striped">
                <thead>
	                <tr>
	                  <th>Name</th>
	                  <th>Date</th>
	                  <th>Time</th>
	                  <th>Duration (h)</th>
	                  <th>Location</th>
	                  <th>Description</th>
	                  <th>Images</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
                	
<?php
foreach($eventList as $event)
{
//clears image list
$imageList = "";	

//gets the images
$this->db->where('eventID', $event->eventID);
$this->db->from("event_media");
$query = $this->db->get();
$mediaList = $query->result();
$mediaCount =  $this->db->count_all_results();
$count = 0;
//checks if the count is greater than 0
if($mediaCount > 0)
{
	foreach ($mediaList as $image) {
		if($count % 2 == 0) {
			$imageList .= '<div class="row" style="text-align: center;">';
		}		
		
		$imageList .= '<div class="col-md-6" style="padding: auto; margin: 5px; width:auto;">
		<a href="'.$image->link.'" target="_blank"><img src="'.$image->link.'" class="img-responsive" width="50px" style="padding: 0px; margin-bottom: 5px; display:inline-block;position:relative;"></a>
		<button title="Delete Image" id="deleteEventImage" data-img="'.$image->id.'" style="position:absolute;top:0; right:0; z-index:1;" class="btn btn-danger btn-xs">X</button>
		</div>';
		
		if($count % 2 != 0) {
			$imageList .= '</div>';
		}
		
		$count++;	
	}
	
	if($count < 4)
	{
		$imageList .= '<button title="Add Image" id="btnAddImage" data-id="'.$event->eventID.'" class="btn btn-link">+image</button>';
	}
}	
	 echo'          <tr>
	                  <td>'.$event->eventName.'</td>
	                  <td>'.$event->date.'</td>
	                  <td>'.$event->eventTime.'</td>
	                  <td>'.$event->duration.'</td>
	                  <td>'.$event->location.'</td>
	                  <td>'.$event->description.'</td>
	                  <td>'.$imageList.'</td>
	                  <td><button class="btn btn-sm btn-warning" data-id="'.$event->eventID.'" data-name="'.$event->eventName.'" data-desc="'.htmlentities($event->description).'" data-location="'.$event->location.'" data-duration="'.$event->duration.'" data-time="'.$event->eventTime.'" data-date="'.$event->date.'" id="btnEdit" />edit</button></td>
	                  <td><button title="Delete Image" id="deleteEvent" data-id="'.$event->eventID.'" class="btn btn-danger btn-sm">delete</button></td>
	                </tr>
	      ';          
}
?>
                </tbody>
                <tfoot>
	                <tr>
	                  <th>Name</th>
	                  <th>Date</th>
	                  <th>Time</th>
	                  <th>Duration (h)</th>
	                  <th>Location</th>
	                  <th>Description</th>
	                  <th>Images</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </tfoot>
              </table>
            </div></div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>

  </div>
  <!-- /.content-wrapper -->

<!-- edit-events-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEdit">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit Event</h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
			      	<form id="editEventForm" enctype="multipart/form-data">
		              <div class="box-body">
		              	
		              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
		                
		                <div class="form-group">
		                  <input type="text" class="form-control" name="name" id="name" placeholder="Event Name">
		                </div>
		                
		                <div class="form-group">
			                <div class="input-group date">
			                  <div class="input-group-addon">
			                    <i class="fa fa-calendar"></i>
			                  </div>
			                  <input type="text" class="form-control pull-right" name="date" id="datepicker" placeholder="Date">
			                </div>
			            </div>
		
		              	<div class="bootstrap-timepicker">
			                <div class="form-group">
			                  <div class="input-group">
			                  	<div class="input-group-addon">
			                      <i class="fa fa-clock-o"></i>
			                    </div>
			                    <input type="text" class="form-control timepicker" name="time" id="time" placeholder="Time">
			                  </div>
			                </div>
			            </div>
		              	<div class="form-group">
		                  <div class="input-group">
		                    <input type="number" class="form-control" name="duration" id="duration" placeholder="Duration">
		
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
		                    <input type="text" class="form-control" name="location" id="location" placeholder="Location">
		                  </div>
		                </div>
		              	<div class="form-group">
							<textarea id="description" name="description" rows="8" cols="150" placeholder="Description"></textarea>
		                </div>
		                <br />
						  <input type="hidden" name="eventID" id="eventID" />
		              </div>
	                
	      		</div>
	      	</div>
	      </div>
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	        <button type="submit" id="btnEditModal" class="btn btn-success">Save Changes</button>
	      </div>
	      </form>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.edit-events-modal --> 

<!-- upload-modal -->
<div class="example-modal" >
	<div class="modal" id="modalUpload">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Add Image</h4>
	      </div>
	    <form id="uploadForm" enctype="multipart/form-data">
	    	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
	      			<div class="form-group">
	                  <input type="file" id="img" name="img">
					  <input type="hidden" id="imageID" name="imageID">
	                  <p class="help-block">Upload an image less than 2 MB and dimensions 400x300 or it will be resized accordingly.</p>
	                </div>
				</div>
	      	</div>
	        <div class="modal-footer">
	          <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	          <button type="submit" id="btnUploadModal" class="btn btn-success">Save Changes</button>
	        </div>
	      </form>
	      </div>
	      <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.upload-modal --> 


                
<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<!-- bootstrap time picker -->
<script src="<?php echo base_url(); ?>plugins/timepicker/bootstrap-timepicker.min.js"></script>
<!-- CK Editor -->
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- page script -->
<script>
	$(function () {
	    $('.eventTable').DataTable({
	      "paging": true,
	      "lengthChange": true,
	      "searching": true,
	      "ordering": false,
	      "info": false,
	      "autoWidth": true
	    });
	    
	    //initializes the CK editor instance
		CKEDITOR.replace('description');
	    
	    //Date picker
	    $('#datepicker').datepicker({
	      autoclose: true
	    });
	
	    //Timepicker
	    $(".timepicker").timepicker({
	      showInputs: false
	    });
	});
	
	$(document).ready(function() {
		//delete image on events
		$(document).on('click', "#deleteEventImage",function() {
			
			var data = $(this).data("img");
			
			var c = confirm('Are you sure you want to delete this image?');
			
			if (c)
			{
				$.post('events/deleteImg',{id:data}, function(result, status){
					
			        if (status)
			        {
			        	alert("Image Deleted Successfully!");
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
				window.location = $("#baseURL").val() + "admin/events";
			}
			
		});
		
		//delete event
		$(document).on('click', "#deleteEvent",function() {
			
			var data = $(this).data("id");
			
			var c = confirm('Are you sure you want to delete this event?');
			
			if (c)
			{
				$.post('events/delete',{id:data}, function(result, status){
			        if (status)
			        {
			        	alert("Event Deleted Successfully!");
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			    
			    window.location = $("#baseURL").val() + "admin/events";
			}
			
		});
		
		//Edit Modal Popup
		$(document).on('click', "#btnEdit",function() {
			
			//gets the data
			var id = $(this).data("id");
			var description = $(this).data("desc");
			var name = $(this).data("name");
			var location = $(this).data("location");
			var time= $(this).data("time");
			var duration = $(this).data("duration");
			var date = $(this).data("date");
			
			//passes the value to the modal
			$("#eventID").val(id);
			$("#name").val(name);
			CKEDITOR.instances.description.setData(description);
			$("#time").val(time);
			$("#datepicker").val(date);
			$("#location").val(location);
			$("#duration").val(duration);
			
			//shows the modal
			$('#modalEdit').modal('show');
		});
		
		//Edit event
		$(document).on('submit', "#editEventForm",function(e) {
			
			e.preventDefault();
			
			$.ajax({
				url: "events/edit",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
					alert("Event Edited Successfully!")
					window.location = $("#baseURL").val() + "admin/events";
				}
			});
		});
		
		//Upload Modal Popup
		$(document).on('click', "#btnAddImage",function() {
			
			//gets the data
			var id = $(this).data("id");
			
			//passes the value to the modal
			$("#imageID").val(id);
			
			//shows the modal
			$('#modalUpload').modal('show');
		});
		
		//add event
		$(document).on('submit', "#uploadForm",function(e) {
			
			e.preventDefault();					
			$.ajax({
				
				url: "events/uploadImage",
				type: "POST",
				data: new FormData(this),
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
			
		});
	});
</script>
