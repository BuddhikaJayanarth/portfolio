<?php
	include_once("userScripts.php");
	
		if($this->session->userdata('userID') == ''){
		
	}
	else{
		$uid= $this->session->userdata('userID');
		$uniqueid= uniqid();
		$uniquepid= $uid.$uniqueid;
	}
	
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
       <input type="hidden" id="userID" value="<?php echo $uid ?>" />
       <input type="hidden" id="pID" value="<?php echo $uniquepid ?>" />
        <!-- /.col -->
        <div class="col-md-8">
        	<div class="box">
            	<div class="box-header with-border">
                	<h3 class="box-title">CREATE PROJECT</h3>
                </div>
                <div class="box-body">
                

		<!--Create Project Form-->


                
            	<form class="form-horizontal" id="createPForm">
                      <div class="form-group">
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="projTitle" name="" placeholder="Project Title" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <textarea class="form-control" id="projDescrip" placeholder="Project Description"></textarea>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2">Project Category</label>
                            <div class="col-sm-8">
                                <select class="form-control" id="projCat" placeholder="Project Category">


		<!--Retrieving Categories from database-->



								<?php
		
								  $this->db->select('*');
								  $this->db->from('categories_project');
								  $query = $this->db->get();
								  $output = $query->result();			
								  foreach ($output as $o)
								  {
									  echo '
									  	<option value="'. $o->catID .'">'. $o->catName .'</option>
									  ';
								  }
							  	?>                                    
                                </select>
                                
                          </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-sm-2">Duration</label>
                            <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" id="projStart" name="" placeholder="Start" />
                            </div>
                            <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" id="projEnd" name="" placeholder="End(optional)" />
                            </div>
                        </div>
                        
                       
                      <div class="form-group">
                        <div class="col-sm-10">
                        <button type="button" id="createBtn" class="btn btn-success">Create Project</button>
                        <span style="float: right"><a href="<?php echo base_url().'user/';?>profile" class="btn btn-danger">Cancel</a></span>
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
*** Validate text fields
**/
/////////////////////////////////////////////////////////////////////


$(document).on('click','#createBtn', function(){
	var userid = $('#userID').val();
	var projtitle = $('#projTitle').val();
	var projdesc = $ ('#projDescrip').val();
	var projcat = $ ('#projCat option:selected').val();
	var dash = '-';
	var projstartdate1 = $('#projStart').val();
	var pid =  $('#pID').val();

/////////////////////////////////////////////////////////////////////
/**
*** converts date format from mm/dd/yyyy to yyyy-mm-dd
**/
/////////////////////////////////////////////////////////////////////
	var convertdate1 = projstartdate1.toString();
	var projstartdate = convertdate1[6]+convertdate1[7]+convertdate1[8]+convertdate1[9]+dash+convertdate1[0]+convertdate1[1]+dash+convertdate1[3]+convertdate1[4];
	
	
	var projenddate1 = $('#projEnd').val();
/////////////////////////////////////////////////////////////////////
/**
*** converts date format from mm/dd/yyyy to yyyy-mm-dd
**/
/////////////////////////////////////////////////////////////////////
	var convertdate2 = projenddate1.toString();
	var projenddate = convertdate2[6]+convertdate2[7]+convertdate2[8]+convertdate2[9]+dash+convertdate2[0]+convertdate2[1]+dash+convertdate2[3]+convertdate2[4];

	if(projenddate == 'NaN-undefinedundefined-undefinedundefined'){
	projenddate = '0000-00-00';	
	}
		
	
	var projcreatedate = new Date();
	var d = projcreatedate.getDate();
	var m = projcreatedate.getMonth()+1;
	var y = projcreatedate.getFullYear();
	if(d<10){
		d='0'+d;
	} 
	if(m<10){
		m='0'+m;
	} 
	var projcreatedate = y+'-'+m+'-'+d;
	var projimagelink = 'NULL';
	
/////////////////////////////////////////////////////////////////////
/**
*** Post to database
**/
/////////////////////////////////////////////////////////////////////

	
					$.ajax({
					url:"projects/createproject",
					type:"POST",
					data:{pid:pid,
						userid:userid,
						  projtitle:projtitle,
						  projdesc:projdesc,
						  projcat:projcat,
						  projstartdate:projstartdate,
						  projenddate:projenddate,
						  projcreatedate:projcreatedate,
						  projimagelink:projimagelink},
						success: function(data){
							if(data == 'done'){
								alert("created project");
								window.location = $('#baseURL').val()+'/user/projectprofile?projid='+pid;
							}
							else{
								alert("Unable to create project");
							}
							
						  }
				    });  
	  
  });
  });
  
  </script>
  