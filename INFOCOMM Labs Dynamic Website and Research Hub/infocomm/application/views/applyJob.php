<?php
//function checks if deadline has passed
//Code source: https://stackoverflow.com/questions/2113940/compare-given-date-with-today
function isFuture($time)
{
    return (strtotime($time) > time());
}
$jobID = $_GET["job"];
$userSession = $this->session->userdata('userID');
if(isset($_GET["RL"])){
	$requiredLogin = $_GET["RL"];
	echo '<input type="hidden" id="RL" value="'.$requiredLogin.'"/><input type="hidden" id="loggedIn" value="'.$userSession.'"/>';
}
$placeholder = 'Your Name';
if(isset($userSession)){
	$this->db->select('fname, lname');
	$this->db->from('users');
	$this->db->where('userID', $userSession);
	$this->db->where('status', 'Activated');
	
	$query = $this->db->get();
	$output = $query->result();
	foreach($output as $result){
		$fname = $result->fname;
		$lname = $result->lname;		
	}
	$placeholder = '';
}

$jobOutput = "";
$query = $this->db->query("SELECT title FROM vacancies WHERE vID='$jobID' LIMIT 1");
foreach($query->result_array() as $row){
	$jobTitle = $row['title'];
}
$query2 = $this->db->query("SELECT * FROM vacancies WHERE vID !='$jobID' AND title='$jobTitle' AND isFilled='No' ORDER BY vID DESC LIMIT 2");
foreach($query2->result_array() as $row){
	if(isFuture($row['deadline'])){
	$jobOutput .= '<div class="row">
	           	  <h2>Job Details</h2>
	    			<p class="lead">'.$row['title'].'</p>
					<span style="float: right"><a href="'.base_url().'/applyJob?job='.$row['vID'].'&RL='.$row['loginRequired'].'">Apply Now!</a></span>
			        <div class="table-responsive">
			          <table class="table">
			            <tr>
			              <th style="width:50%">Deadline:</th>
			              <td>'.$row['deadline'].'</td>
			            </tr>
			            <tr>
			              <th>Date Posted:</th>
			              <td>'.date('Y-m-d', strtotime($row['dateCreated'])).'</td>
			            </tr>
			            <tr>
			              <th>Type:</th>
			              <td>'.$row['vCat'].'</td>
			            </tr>
			            <tr>
			              <th>Job Description:</th>
			              <td>
			          		<p>- '.$row['description'].'</p>
						  </td>
			            </tr>
			          </table>
			        </div>
	    	   </div>';
	}
}
?>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">

    <!-- Main content -->
    <section class="content">
    	<div class="row">
    		<div class="col-xs-6">
    		  <!-- general form elements -->
	          <div class="box box-success">
	            <div class="box-header with-border">
	              <h3 class="box-title">Apply</h3>
	            </div>
	            <!-- /.box-header -->
	            <!-- form start -->
	            <form id="addJobForm" enctype="multipart/form-data">
	              <div id="addJobFormBody" class="box-body">
	                <input type="hidden" name="jobID" value="<?php echo $jobID ?>" />
	                <div class="form-group">
	                  <input type="text" id="applicantName" name="applicantName" class="form-control" value="<?php if(isset($userSession)){echo $fname.' '.$lname; } ?>" placeholder="<?php echo $placeholder ?>">
	                </div>
	                
	                <div class="form-group">
	                  <div class="input-group">
	                    <div class="input-group-addon">
	                      <i class="fa fa-envelope"></i>
	                    </div>
	                    <input type="email" class="form-control" name="applicantEmail" id="applicantEmail" placeholder="Email">
	                  </div>
	                </div>
	                
	                <div class="form-group">
	                  <div class="input-group">
	                    <div class="input-group-addon">
	                      <i class="fa fa-phone"></i>
	                    </div>
	                    <input type="tel" id="applicantPhone" name="applicantPhone" class="form-control" placeholder="Contact">
	                  </div>
	                </div>
	                
	                <div class="form-group">
	                  <input type="url" id="applicantWebsite" name="applicantWebsite" class="form-control" placeholder="Website">
	                </div>
	                
	                <div class="form-group has-feedback">
                        <input type="text" class="form-control" name="country" id="country" placeholder="Country">
                        <span class="glyphicon glyphicon-globe form-control-feedback"></span>
                     </div> 
	                
	                <div class="form-group">
	                  <label for="exampleInputFile">Upload CV <span style="color:#F4070B; padding:5px;"><strong>(Upload file should be pdf, Maximum file size 1MB) **</strong></span></label>
	                  <input type="file" name="applicantCV" id="applicantCV">
	                </div>
	                
                    <div id="referenceBox">
	                <label>References</label>
		            
		            <div class="form-group">
	                  <input type="text" id="applicantRefName" name="applicantRefName[]" class="form-control" placeholder="Reference Name">
	                </div>
	                
	                <div class="form-group">
	                  <input type="text" id="applicantRefPosition" name="applicantRefPosition[]" class="form-control" placeholder="Reference Position">
	                </div>
		            
	              	<div class="form-group">
	                  <div class="input-group">
	                    <div class="input-group-addon">
	                      <i class="fa fa-phone"></i>
	                    </div>
	                    <input type="tel" class="form-control" name="applicantRefContact[]" id="applicantRefContact" placeholder="Reference Contact">
	                  </div>
	                </div>
	                </div><!----------Add reference box---->
	                <button class="btn btn-danger" id="btnAddReference" type="button">+ Add Another Reference</button>
	                <!-- /.box-body -->
	                
	                <br />
	                
	                <!-- checkbox -->
	                <div class="form-group">
	                  <div class="checkbox">
	                    <label>
	                      <input type="checkbox" id="t_c">
	                      I consent that the information provided here is correct and honest.
	                    </label>
	                  </div>
	                </div>
					
	                <div class="box-footer">
	                  <button type="submit" id="applyJobBtn" class="btn btn-success">Submit Application</button>
	                </div>
	              </div>
	            </form>
                <input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	          </div>
	          <!-- /.box -->
    		</div>
    		<div class="col-xs-6">
		        <?php echo $jobOutput ?>   
	           
    		</div>
    	</div>
    </section>
   
    
  </div>
  <!-- /.content-wrapper -->
  
<!-- includes footer -->

<!-- ./wrapper -->


<!-- page script -->

