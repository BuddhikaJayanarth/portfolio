<?php ;
//sets date for today to compare to db
$today = date('Y/m/d');

//query to get the events
$this->db->order_by('date', 'DESC');
$this->db->where('date >=', $today);
$this->db->where('events.eventID >', 0);
$this->db->from("events");
$query2 = $this->db->get();
$eventList = $query2->result();
$eventCount = $this->db->count_all_results();

//query to get the events
$this->db->order_by('date', 'DESC');
$this->db->where('date <', $today);
$this->db->where('events.eventID >', 0);
$this->db->from("events");
$query = $this->db->get();
$pastList = $query->result();
$pastCount = $this->db->count_all_results();

$events = '';
$pastEvents = '';

//creates the upcoming events section
foreach($eventList as $e)
{
	$img = " ";
	
	$this->db->where('eventID', $e->eventID);
	$this->db->from("event_media");
	$this->db->limit(1);
	$query = $this->db->get();
	$mediaList = $query->result();
	
	foreach ($mediaList as $image) {
		$img = $image->link;
	}
	
	$events .= '<tr>';
	$events .= makeEvent($e, 'eventpage?id=', $img);
	$events .= '</tr>';

}

//creates the past events section
foreach($pastList as $e)
{
	$img = " ";
	
	$this->db->where('eventID', $e->eventID);
	$this->db->from("event_media");
	$this->db->limit(1);
	$query = $this->db->get();
	$mediaList = $query->result();
	
	foreach ($mediaList as $image) {
		$img = $image->link;
	}
	
	$pastEvents .= '<tr>';
	$pastEvents .= makeEvent($e, 'eventpage?id=', $img);
	$pastEvents .= '</tr>';
}

//Makes an event cell
function makeEvent($event, $Elink, $img) {
	
	
	$start_time = date('g:iA', strtotime($event->eventTime));
	$end_time = date("g:iA", strtotime('+'.$event->duration.' hour',strtotime($event->eventTime)));
	$date = date('D, d M Y', strtotime($event->date));
	
	return '
			<td style="padding: 25px;" style="text-align:left">
				
				<div class="col-xs-6 pull-right" style="text-align:left">
		        	<a href="'.$Elink.$event->eventID.'">
		        		<img class="img-responsive" style="margin: 0 auto;" src="'.$img.'">
		        	</a>
		        </div>		
		        <div class="col-xs-6" style="font-size: 18px;" style="text-align:left">
		        	<a href="'.$Elink.$event->eventID.'"><h2 style="color:#00a65a; text-align: left">'.$event->eventName.'</h2></a>
		            <p style="text-align:left"><span style="font-style:italic; font-weight:600;">When:</span> '.$date.'</p>
		            <p style="padding-left:3em; text-align:left">'.$start_time.' - '.$end_time.'</p>
		            <p style="text-align:left"><span style="font-style:italic; font-weight:600;">Where:</span> '.$event->location.'</p>
		            <p style="text-align:left"><span style="font-style:italic; font-weight:600;">What:</span> '.truncate($event->description).'</p>
		        </div>
			</td>';
}

/* Function Source : https://stackoverflow.com/questions/3161816/get-first-n-characters-of-a-string
 * Access on: 19th October 2017
 */
function truncate($string,$length=300,$append=" &hellip;") {
  $string = trim($string);

  if(strlen($string) > $length) {
    $string = wordwrap($string, $length);
    $string = explode("\n", $string, 2);
    $string = $string[0] . $append;
  }

  return $string;
}
?>
  <!-- Full Width Column -->
  <div class="content-wrapper">
    
    <div style="height:600px; background-attachment: fixed;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover; background-image: url('<?php echo base_url(); ?>resources/event-banner.jpg')")>
		
    	<div class="container" style="padding-top: 15%;">
              <h1 class="text-center text-bold" style='font-size: 55px; color:white;'>EVENTS AT INFOCOMM</h1>
        </div>
	</div>
	
    <div class="container">	
      <!-- Main content -->
      <section class="content">
     <br /><br />
	     <div class="row">
		     <div class="col-md-12">
			     <div class="box box-success">
				     <div class="box-header">
				     	<h2 class="text-center text-bold" style="color:#00a65a; text-decoration: underline">UPCOMING EVENTS</h2>  
				     </div>
				     <div class="box-body">
		              <table class="eventTables table">
		                <thead><tr><th></th></tr></thead>
						<tbody>
			            	<?php echo $events; ?>
			            </tbody>
		              </table>
		            </div>
			     </div>
		     </div>
	     </div>
	     
	     <div class="row">
		     <div class="col-md-12">
			     <div class="box box-success">
				     <div class="box-header">
				     	<h2 class="text-center text-bold" style="color:#00a65a; text-decoration: underline">PAST EVENTS</h2>  
				     </div>
				     <div class="box-body">
		              <table class="eventTables table">
		                <thead><tr><th></th></tr></thead>
						<tbody>
			            	<?php echo $pastEvents; ?>
			            </tbody>
		              </table>
		            </div>
				</div>
		     </div>
	     </div>
	     
      </section>
      <!-- /.content -->
    </div>
    <!-- /.container -->
  </div>
  <!-- /.content-wrapper -->
  

