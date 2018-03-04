<?php
	include_once("userScripts.php");
?>
  <!-- Full Width Column -->
  

      <!-- Main content -->
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        My Projects
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li><a href="#">Examples</a></li>
        <li class="active">User profile</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">

      <div class="row">
      <?php include_once("profileSideMenu.php")?>
       <input type="hidden" id="userID" value="<?php echo $userID ?>" />
        <!-- /.col -->
        <div class="col-md-8">
        	<div class="box">
            	<div class="box-header with-border">
                	<h3 class="box-title">EDIT PROJECT</h3>
                    
                </div>
                <div class="box-body">
                

		<!--Edit Project Form-->

<?php
		///////////////////////////////////////////////////////////
		/**		    	
		*** If no url parameters redirect to profile
		**/
		/////////////////////////////////////////////////////////////
		
			if(count($_GET)==0) {
     			echo '<script type="text/javascript">window.location = "'.base_url().'user/profile"</script>';
			}

		
		///////////////////////////////////////////////////////////
		/**		    	
		*** Autofill the form with the project details
		**/
		/////////////////////////////////////////////////////////////
			 
			$this->db->select('*');
			$this->db->from('user_projects');
			$this->db->where('user_projects.projectID', $_GET["projid"]);
			$projectid = $_GET["projid"];
			$query = $this->db->get();
			$output3 = $query->result();
			$o4;
			$row=0;
			foreach ($output3 as $o3)
			{
			$o4=$o3;	
			}
?>
				<input type="hidden" id="projectID" value="<?php echo $projectid;?>" />
                
                <!--Hidden input type holding unconverted startdate form the database-->
              	<input type="hidden" id="unconvertedstart" value="<?php echo $o4->startDate;?>" />
                <input type="hidden" id="unconvertedend" value="<?php echo $o4->endDate;?>" />

                
            	<form class="form-horizontal" id="createPForm">
                      <div class="form-group">
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="projTitle" name="" placeholder="Project Title" value="<?php echo $o4->projectTitle;?>"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <textarea class="form-control" id="projDescrip" placeholder="Project Description"><?php echo $o4->description;?></textarea>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2">Project Category</label>
                            <div class="col-sm-8">
                                <select class="form-control" id="projCat" placeholder="Project Category" >


		<!--Retrieving Categories from database-->



								<?php
		
								  $this->db->select('*');
								  $this->db->from('categories_project');
								  $query = $this->db->get();
								  $output = $query->result();			
								  foreach ($output as $o)
								  {
									  echo '
									  	<option value="'. $o->catID .'" ';
										if ($o->catID == $o4->catID){
											echo '
												selected="selected";
											';
										}
										echo '>'. $o->catName .'</option>
									  ';
								  }
							  	?>                                    
                                </select>
                                
                          </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2">Duration</label>
                            <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" id="projStart" name="" placeholder="Start mm/dd/yyyy" value="" />
                            </div>
                            <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" id="projEnd" name="" placeholder="End yyyy-mm-dd(optional)" value="" />
                            </div>
                        </div>
                        
                        <div class="form-group">
                        <label class="control-label col-sm-2">Project Image</label>
                            <div class="col-sm-2">
                               <?php
			
								  $imagelink1= $o4->imageLink;
								  if($imagelink1 == NULL || $imagelink1 == 'NULL'){
									  $imagelink1 ='default.jpg';
									  
								  }
								?>
            
            					<img class="profile-user-img img-responsive img-circle" src="<?php echo base_url(); ?>/resources/projects/profile_pic/<?php echo $imagelink1; ?>" alt="User profile picture" width="300" height="300">
                            </div>
                            
                            <div class="col-sm-2">
                        		<a data-id3="<?php echo $_GET["projid"] ?>" id="editprojectimage" class="pull-left btn-box-tool" data-toggle="modal" href="#EditprojectimageModal" data-target="#EditprojectimageModal"><i class="fa fa-pencil"> project image</i></a>
                        	</div>
                        </div>
                        
                      <div class="form-group">
                        <div class="col-sm-10">
                        <button type="submit" id="editBtn" class="btn btn-success">Save Changes</button>
                        <button type="button" id="deleteBtn" class="btn btn-danger">Delete Project</button>
                        <span style="float: right"><a href="<?php echo base_url() ?>user/profile" class="btn btn-danger">Cancel</a></span>
                        </div>
                      </div>
                    </form>
                    </div>
          	</div>
      <!-- /.box -->
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

    </section>
    <!-- /.content -->
    
<!-- upload-modal -->
<div class="example-modal" >
	<div class="modal" id="EditprojectimageModal">
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
					  <input type="hidden" id="imageID" name="imageID" value="<?php echo $_GET["projid"]; ?>">
	                  <p class="help-block">Upload an image less than 2 MB and dimensions 80x80 or it will be resized accordingly.</p>
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
    
    
  </div>
     
  <!-- /.content-wrapper -->
  
<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- InputMask -->
<script src="<?php echo base_url(); ?>plugins/input-mask/jquery.inputmask.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- Select2 -->
<script src="<?php echo base_url(); ?>plugins/select2/select2.full.min.js"></script>
<!-- date-range-picker -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/daterangepicker/daterangepicker.js"></script>
<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<!-- bootstrap time picker -->
<script src="<?php echo base_url(); ?>plugins/timepicker/bootstrap-timepicker.min.js"></script>
<!-- SlimScroll -->
<script src="<?php echo base_url(); ?>plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="<?php echo base_url(); ?>plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url(); ?>dist/js/demo.js"></script>
<script>
$(function () {

	$('#projStart').datepicker({
      autoclose: true
	});
	
	$('#projEnd').datepicker({
      autoclose: true
	});
});
</script>
  
  <script>
  
  $(document).ready(function() {
	  
/////////////////////////////////////////////////////////////////////
/**
*** Convert the dates retrieved from database to correct format
**/
/////////////////////////////////////////////////////////////////////
	var unconverted1 = $("#unconvertedstart").val();
	var unconverted2 = unconverted1.toString();
	var convertedstartdate = unconverted2[5]+unconverted2[6]+'/'+unconverted2[8]+unconverted2[9]+'/'+unconverted2[0]+unconverted2[1]+unconverted2[2]+unconverted2[3];
	$("#projStart").val(convertedstartdate);

	var unconverted3 = $("#unconvertedend").val();
	var unconverted4 = unconverted3.toString();
	var convertedenddate = unconverted4[5]+unconverted4[6]+'/'+unconverted4[8]+unconverted4[9]+'/'+unconverted4[0]+unconverted4[1]+unconverted4[2]+unconverted4[3];
	if(convertedenddate == '00/00/0000'){
		convertedenddate = '';
	}
	$("#projEnd").val(convertedenddate);

		/////////////////////////////////////////////////////////////////////
		/**
		*** prepares to post an update to user_projects table
		**/
		/////////////////////////////////////////////////////////////////////
		$(document).on('click','#editBtn', function(){
			var projid = $('#projectID').val();
			var projtitle = $('#projTitle').val();
			var projdesc = $ ('#projDescrip').val();
			var projcat = $ ('#projCat option:selected').val();
			var dash = '-';
			var projstartdate1 = $('#projStart').val();
		//	alert(projstartdate1);
		/////////////////////////////////////////////////////////////////////
		/**
		*** converts start date format from mm/dd/yyyy to yyyy-mm-dd
		**/
		/////////////////////////////////////////////////////////////////////
			var convertdate1 = projstartdate1.toString();
			var projstartdate = convertdate1[6]+convertdate1[7]+convertdate1[8]+convertdate1[9]+dash+convertdate1[0]+convertdate1[1]+dash+convertdate1[3]+convertdate1[4];
				$("#projStart").val(projstartdate);
		
			
			var projenddate1 = $('#projEnd').val();
		/////////////////////////////////////////////////////////////////////
		/**
		*** converts end date format from mm/dd/yyyy to yyyy-mm-dd
		**/
		/////////////////////////////////////////////////////////////////////
		
				var convertdate2 = projenddate1.toString();
				var projenddate = convertdate2[6]+convertdate2[7]+convertdate2[8]+convertdate2[9]+dash+convertdate2[0]+convertdate2[1]+dash+convertdate2[3]+convertdate2[4];
		  
				if(projenddate == 'NaN-undefinedundefined-undefinedundefined'){
					projenddate = '0000-00-00';	
				}
			$("#projEnd").val(projenddate);
				
			
			var projimagelink = 'null';
		
			
		/////////////////////////////////////////////////////////////////////
		/**
		*** Post to database
		**/
		/////////////////////////////////////////////////////////////////////
		
		//	alert(projid + projtitle + projdesc + projcat + projstartdate + projenddate + projimagelink);	
							$.ajax({
							url:"projects/editproject",
							type:"POST",
								  data:{projid:projid,
								  projtitle:projtitle,
								  projdesc:projdesc,
								  projcat:projcat,
								  projstartdate:projstartdate,
								  projenddate:projenddate,
								  projimagelink:projimagelink},
								success: function(data){
									alert(data);
									if(data == 'done'){
										window.location = $('#baseURL').val()+'user/profile';
									}
									else{
										alert("Unable to edit project");
									}
									
								  }
							});  
			  
		});
		  

		/////////////////////////////////////////////////////////////////////
		/**
		*** prepares to delete a project
		**/
		/////////////////////////////////////////////////////////////////////
		$(document).on('click','#deleteBtn', function(){
		
		/////////////////////////////////////////////////////////////////////
		/**
		*** Delete confirmation
		**/
		/////////////////////////////////////////////////////////////////////	
			
			if (confirm("Are you sure you want to delete this project?") == true) {				
				var projid = $('#projectID').val();
					
				
					
				/////////////////////////////////////////////////////////////////////
				/**
				*** Post delete values to database
				**/
				/////////////////////////////////////////////////////////////////////
				$.ajax({
				url:"projects/deleteproject",
				type:"POST",
					  data:{projid:projid},
					success: function(data){
						alert(data);
						if(data == 'done'){
						window.location = $('#baseURL').val()+'user/profile';
						}
						else{
							alert("Unable to delete project");
						}
						
					  }
				});
			}			  
			  
		});		  
		 
  //upload image
  
		$(document).on('submit', "#uploadForm",function(e) {
			
	var projid = $('#projectID').val();

			e.preventDefault();					
			$.ajax({
				
				url: "editproject/uploadImage",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
					if(result == "Success")
					{
						alert("Added image Successfully! (cache may be needed cleared to reflect changes)");
						window.location = $('#baseURL').val()+'user/editproject?projid='+projid;
					}
					else
					{
						window.location = $('#baseURL').val()+'user/editproject?projid='+projid;
						//alert(result);
					}
				}					
			});
			
		});  		 
		  
		  
  });
  
  </script>
  