<?php
$this->db->select("*");
$this->db->from('vacancies v');
$this->db->join('v_applications a', 'v.vID = a.vID');
$query = $this->db->get();
$output = $query->result();
?> 


  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Applications
      </h1>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">

          <div class="box">
            <!-- /.box-header -->
            <div class="box-body"><div class="table table-responsive">
              <table id="example1" class="table table-bordered table-striped">
              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <thead>
	                <tr>
	                  <th>Date</th>
					  <th>Position</th>
	                  <th>Name</th>
	                  <th>Email</th>
	                  <th>Contact</th>
	                  <th>Country</th>
	                  <th>Website</th>
	                  <th>CV</th>
	                  <th>References</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
                	
<?php
//queries the databse for the categories_project table
$query = $this->db->get("vacancies");
$vacancies = $query->result();
$vac = '';

$query = $this->db->get("v_appreferences");
$allReferences = $query->result();


foreach($output as $o)
{
				$count = 0;
				$refs = ' ';
								
				foreach($vacancies as $v)
				{
					if ($v->vID == $o->vID)
					{
						$vac = $v->title;
					}
				}
				
				
					foreach($allReferences as $r)
					{
						if ($r->vAppID == $o->appID)
						{
							$refs .= '
							<p><b>'.$r->name.'</b></p>
							<p>'.$r->position.'</p>
							<p>'.$r->contact.'</p>
							<br />
							';
							$count++;
						}
					}
				
				if ($count > 0)
				{	
					$tdRef = '<td><button class="btn btn-warning" data-data="'.$refs.'" data-name="'.$o->name.'" id="btnViewRef" />View References</button></td>';	
				}
				else {
					$tdRef = '<td>N/A</td>';
				}
				
				echo '
					<tr>
					  <td>'.$o->dateApplied.'</td>
	                  <td><a href="'.base_url() .'index.php/admin/viewVacancies">'.$vac.'</a></td>
	                  <td>'.$o->name.'</td>
	                  <td><a href="mailto:'.$o->email.'?subject=Response To Job Application For Position: '.$vac.' At Infocomm">'.$o->email.'</a></td>
	                  <td>'.$o->contact.'</td>
	                  <td>'.$o->country.'</td>
	                  <td>'.$o->websiteLink.'</td>
	                  <td><a href="'.$o->CV.'">CV</a></td>
	                  '.$tdRef.'
					  <td><button class="btn btn-danger" data-id="'.$o->appID.'" id="btnDeleteApp"/>delete</button></td>
					</tr>
					';
}
?>

<!-- references-modal -->
<div class="example-modal" >
	<div class="modal" id="modalViewReferences">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header" style="text-align: center">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">References for <div id="nameApplicant"></div></h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
      			<div class="col-xs-12" style="text-align: center">
			      	<div id="referenceList"></div>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="userIDModal" />
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
	      </div>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.references-modal -->
                </tbody>
                <tfoot>
	                <tr>
	                  <th>Date</th>
	                  <th>Position</th>
	                  <th>Name</th>
	                  <th>Email</th>
	                  <th>Contact</th>
	                  <th>Country</th>
	                  <th>Website</th>
	                  <th>CV</th>
	                  <th>References</th>
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
    <!-- Content Header (Page header) -->    
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
    $("#example1").DataTable();
  });
</script>
<script>
	$(document).ready(function() {
		//Deletes application
		$(document).on('click', "#btnDeleteApp",function() {
			
			var id = $(this).data("id");
			
			var c = confirm('Are you sure you want to delete this application?');
			
			if (c)
			{
				$.post('applications/delete',{id:id}, function(result, status){
			        if (status)
			        {
			          	window.location = $("#baseURL").val() + "admin/applications";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
			
		});
		
		//Edit access modal function
		$(document).on('click', "#btnViewRef",function() {
			
			//gets the data from data-id
			var data = $(this).data("data");
			var name = $(this).data("name");
			
			//passes the values to the modal
			$("#referenceList").html(data);
			$("#nameApplicant").html(name);
			
			//shows the modal
			$('#modalViewReferences').modal('show');
		});
	});
</script>
