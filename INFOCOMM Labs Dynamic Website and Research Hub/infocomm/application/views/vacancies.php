<?php
//gets seperate results for each section
$query = $this->db->get_where('vacancies', array('vCat' => 'Post Doctoral'));
$postdoc = $query->result();

$query = $this->db->get_where('vacancies', array('vCat' => 'PHD'));
$phd = $query->result();

$query = $this->db->get_where('vacancies', array('vCat' => 'Research'));
$research = $query->result();

$query = $this->db->get_where('vacancies', array('vCat' => 'General'));
$general = $query->result();

//function checks if deadline has passed
//Code source: https://stackoverflow.com/questions/2113940/compare-given-date-with-today
function isFuture($time)
{
    return (strtotime($time) > time());
}

//fucntion checks if date is one week from today
function isWeekFromDeadline($time)
{
    return ((strtotime('+1 week', strtotime($time))) < time());
}

//makes a section to display the vacancies depending on the query it recieves
function makeSection($data)
{
	//count manages whether or not to open or close the bootstrap row
	$count = 1;
	    	
	foreach($data as $o)
	{
		//check is it position is already filled
		$isFilled = $o->isFilled;
		
		//sets variables to check if deadline has passed
		$deadline = $o->deadline;
		
		//creates date to display
		$date = date_create($deadline);
		$deadlineDisplay = date_format($date, 'd/m/Y');
		
		//checks to make sure it is not been a week from the deadline then displays
		if (!isWeekFromDeadline($deadline))
		{
			//displays the apply link depending on whether or not deadline has passed
			if (isFuture($deadline)) {
				$applyNow = '<span style="float: right"><a href="'.base_url().'applyJob?job='.$o->vID.'&RL='.$o->loginRequired.'">Apply Now!</a></span>';
			}
			else {
				$applyNow = '<span style="float: right; color: grey;">Applications Closed</span>';
			}
			
			//changes to isFilled if it is filled
			if($isFilled == 'Yes')
			{
				$applyNow = '<span style="float: right; color: grey;">Position Filled</span>';
			}
			
			//splits into new bootstrap row 
			if($count % 2 != 0)
			{
				echo '
					<!-- row -->
	    			<div class="row">
				';
			}
			
			//prints the box for each vacancy
			echo '
			
				<div class="col-xs-6">
	    		  <!-- general form elements -->
		          <div class="box box-success">
		            <div class="box-header with-border">
		              <h3 class="box-title">'.$o->title.'</h3>
		              '.$applyNow.'
		            </div>
			        <div class="table-responsive">
			          <table class="table">
			            <tr>
			              <th>Apply By: <span style="color: red"> '.$deadlineDisplay. ' </span></th>
			            </tr>
			            <tr>
			              <td>'.$o->description.'</td>
			            </tr>
			          </table>
			        </div>
		          </div>
		          <!-- /.box -->
				</div>
			
			';
			
			//closes the bootstrap row
			if($count % 2 == 0)
			{
				echo '
					<!-- row -->
	    			</div>
				';
			}
			
			//count manages whether or not to close the row
			$count++;
		}	
	}	
}
?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">

    <!-- Main content -->
    <section class="content">
    	<h1>Vacancies</h1>
    	
    	<h3>Phd Positions</h3>
    	<!-- phd -->
    	<div id="phd">
			<?php
				///makes the sections according to the query it recieves
	    		makeSection($phd);
	    	?>	
    	</div>
    	<!-- /.phd -->
    	
    	<h3>Post Doctoral Positions</h3>
    	<!-- post doc -->
    	<div id="postDoc">
	    	<?php
	    		///makes the sections according to the query it recieves
	    		makeSection($postdoc);
	    	?>
    	</div>
    	<!-- /.post doc -->
    	
    	<h3>Research Positions</h3>
    	<!-- research -->
    	<div id="research">
	    	<?php
	    		///makes the sections according to the query it recieves
	    		makeSection($research);
	    	?>
    	</div>
    	<!-- /.research -->
    	
    	<h3>General Positions</h3>
    	<!-- general -->
    	<div id="general">
	    	<?php
	    		///makes the sections according to the query it recieves
	    		makeSection($general);
	    	?>
    	</div>
    	<!-- /.general -->
    </section>
   
    
  </div>
  <!-- /.content-wrapper -->
  
<!-- includes footer -->

<!-- ./wrapper -->

