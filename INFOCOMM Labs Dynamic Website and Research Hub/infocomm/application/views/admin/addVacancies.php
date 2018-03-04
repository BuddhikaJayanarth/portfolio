

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
              <h3 class="box-title">Add Vacancies</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form>
              <div class="box-body">
                <input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <div class="form-group">
                  <input type="text" class="form-control" id="title" name="title" placeholder="Title" required="required">
                </div>
                
                <div class="form-group">
	                <div class="input-group date">
	                  <div class="input-group-addon">
	                    <i class="fa fa-calendar"></i>
	                  </div>
	                  <input type="text" class="form-control pull-right" name="deadline" id="datepicker" placeholder="Deadline" required="required">
	                </div>
	            </div>
	            
              	<div class="form-group">
                  <textarea class="form-control" rows="3" name="description" id="description" placeholder="Description" required="required"></textarea>
                </div>
                
                <!-- checkbox -->
                <div class="form-group">
                  <div class="checkbox">
                    <label>
                      <input type="checkbox" id="loginRequired" name="loginReq" value="1">
                      Login Required
                    </label>
                  </div>
                </div>
                
                
                <!-- select -->
                <div class="form-group">
                  <label>Category</label>
                  <select name="cats" id="cats" class="form-control">
                    <option disabled="disabled">Select</option>
                    <option value="PHD">PHD</option>
                    <option value="Post Doctoral">Post Doctoral</option>
                    <option value="Research">Research</option>
                    <option value="General" selected="selected">General</option>
                  </select>
                </div>                        
              </div>
              <!-- /.box-body -->

              <div class="box-footer">
                <button id="btnAddVacancy" class="btn btn-success">Add</button>
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
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<!-- SlimScroll -->
<script src="<?php echo base_url(); ?>plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="<?php echo base_url(); ?>plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url(); ?>dist/js/demo.js"></script>
<!-- CK Editor -->
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>
<!-- page script -->
<script>
  $(function () {
    $("#example1").DataTable();
    $('#example2').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false
    });
  });
</script>
<script>
  $(function () {
    //Date picker
    $('#datepicker').datepicker({
      autoclose: true
    });
    
    //initializes the CK editor instance
	CKEDITOR.replace('description');
		
  });
</script>
<script>
	//Add Vacancy function
	$(document).ready(function() {
		$(document).on('click', "#btnAddVacancy",function(e) {
			
			e.preventDefault();
			
			//gets the values from the form
			var title = $('#title').val();
			var description = CKEDITOR.instances.description.getData();
			var deadline = $("#datepicker").val();
			var category = $("#cats").val();
			var loginReq;
			
			//if the checkbox is checked sets login to 1 else to 0
			if($('#loginRequired').is(":checked"))
				loginReq = 1;
			else
				loginReq = 0;
			
			//gets the value from the datepicker to compare to the current date
			var deadlineDate = $("#datepicker").datepicker("getDate");
			var CurrentDate = new Date();
			
			//validates the deadline and alerts if it is less than today
			if ((deadlineDate - CurrentDate) < 0)
			{
				alert("Date cannot be set to before today!");
			} 
			else
			{	//posts to the controller
				$.post('addVacancies/new',{cats:category, loginReq:loginReq, title:title, description:description, deadline:deadline}, function(result, status){
			        if (status)
			        {
			        	window.location = $("#baseURL").val() + "admin/viewVacancies";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
		});
	});
</script>
