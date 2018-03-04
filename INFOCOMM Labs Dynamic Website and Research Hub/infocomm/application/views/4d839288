<?php ;
//query to get the events
$this->db->order_by('date', 'DESC');
$query = $this->db->get('news');
$newsList = $query->result();
$news = " ";

//creates the upcoming events section
foreach($newsList as $n)
{
	$news .= '<tr>';
	$news .= makeNews($n);
	$news .= '</tr>';

}


//Makes an event cell
function makeNews($news) {
	$date = date('D, d M Y', strtotime($news->date));
	
	return '
			<td padding-right: 100px; padding-left: 100px;" style="text-align:left" >
		        <div class="col-xs-12" style="font-size: 18px;">
		        	<a href="'.base_url().'newsPage?id='.$news->newsID.'"><h2 style="color:	#282828">'.$news->headline.'</h2></a>
		            <p class="text-muted"> '.$news->subHeadline.'</p>
		            
		            <p class="text-muted" style="font-size:12px">'.$date.'</p>
		            <p>'.truncate($news->text).'</p>
		            <p><a href="'.base_url().'newsPage?id='.$news->newsID.'">Read More</a></p>
		        </div>
			</td>';
}

/* Function Source : https://stackoverflow.com/questions/3161816/get-first-n-characters-of-a-string
 * Access on: 19th October 2017
 */
function truncate($string,$length=200,$append=" &hellip;") {
  $string = trim($string);
  $string = strip_tags($string);

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
    background-size: cover; background-image: url('<?php echo base_url(); ?>resources/news-banner.jpg')")>
		
    	<div class="container">
        </div>
	</div>
	
    <div class="container">	
      <!-- Main content -->
      <section class="content">
     <br /><br />
	     <div class="row">
	     	<div class="col-md-1"></div>
		     <div class="col-md-10">
			     <div class="box box-success">
				     <div class="box-body">
		              <table class="newsTables table">
		                <thead><tr><th></th></tr></thead>
						<tbody>
			            	<?php echo $news; ?>
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
  

