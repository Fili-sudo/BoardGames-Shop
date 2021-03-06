import * as React from 'react';
import Typography from '@mui/material/Typography';
import FacebookIcon from '@mui/icons-material/Facebook';
import InstagramIcon from '@mui/icons-material/Instagram';
import YouTubeIcon from '@mui/icons-material/YouTube';
import MailIcon from '@mui/icons-material/Mail';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import ContactPhoneIcon from '@mui/icons-material/ContactPhone';
import Link from '@mui/material/Link';
import Box from '@mui/material/Box';
import FeedBackForm from './FeedBackForm';


const footerArea = {
    paddingLeft: "5%",
    paddingRight: "5%",
    marginTop: "30px",
    display: { xs: 'block', sm: 'block', md: "flex"},
    flexGrow: 1,
    justifyContent: "space-between",
    backgroundColor: "#1976d2",
}
const group = {
    display: "flex",
}
const footerColumn = {
    display: { xs: 'block', sm: 'block', md: "inline-block"},
    margin: "30px 50px 30px 50px"
}

export default function Footer(){


    return (
        <Box sx={footerArea}>
            <Box sx={{ display: { xs: 'none', sm: 'none', md: "inline-block"}, margin: "30px 50px 30px 50px"}}>
                <Typography  variant="h5" component="div" sx={{fontWeight: "700", color: "white", marginBottom: "20px"}}>
                    We are Played Well Games
                </Typography>
                <Box sx={{ display:"block", maxWidth:"300px"}}>
                    <Typography  variant="body2" component="div" sx={{display: "inline"}}>
                        &emsp;
                    </Typography>
                    <Typography  variant="body2" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}} >
                        Welcome to Played Well Games, your number one source for all boardgames. We're dedicated to providing you the best of boardgames, with a focus on dependability and customer service.
                    </Typography>
                </Box>
                <Box sx={{ display:"block", marginBottom: "10px", maxWidth:"300px"}}>
                    <Typography  variant="body2" component="div" sx={{display: "inline"}}>
                        &emsp;
                    </Typography>
                    <Typography  variant="body2" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}} >
                        We're working to turn our passion for boardgames into a booming online store. We hope you enjoy our products as much as we enjoy offering them to you. 
                    </Typography>
                </Box>
                <Box sx={{ display:"block", marginBottom: "10px", maxWidth:"300px"}}>
                    <Typography  variant="body2" component="div" sx={{fontWeight: "400", color: "white"}} >
                        Sincerely,
                    </Typography>
                    <Typography  variant="body2" component="div" sx={{fontWeight: "400", color: "white"}} >
                        David
                    </Typography>
                </Box>
            </Box>
            <Box sx={footerColumn}>
                <Typography  variant="h5" component="div" sx={{fontWeight: "700", color: "white", marginBottom: "20px"}}>
                    Send us your feedback
                </Typography>
                <FeedBackForm/>
            </Box>
            <Box sx={footerColumn}>
                <Typography  variant="h5" component="div" sx={{fontWeight: "700", color: "white", marginBottom: "20px"}}>
                    Folow Us
                </Typography>
                <Box sx={{ display:"block"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        Facebook
                    </Typography>
                    <Link href="https://www.facebook.com/filimon.david" underline="none" color="white">
                        <FacebookIcon sx={{marginLeft: "10px", position:"relative", top: "5px"}}/>
                    </Link>
                </Box>
                <Box sx={{ display:"block"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        Instagram
                    </Typography>
                    <Link href="https://www.instagram.com/filidavid21/" underline="none" color="white">
                        <InstagramIcon sx={{marginLeft: "10px", position:"relative", top: "5px"}}/>
                    </Link>
                </Box>
                <Box sx={{ display:"block"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        Youtube
                    </Typography>
                    <Link href="https://www.youtube.com/channel/UCMlB5BpE0MDSztG8BBsbBsg" underline="none" color="white">
                        <YouTubeIcon sx={{marginLeft: "10px", position:"relative", top: "5px"}}/>
                    </Link>
                </Box>
            </Box>
            <Box sx={footerColumn}>
                <Typography  variant="h5" component="div" sx={{fontWeight: "700", color: "white", marginBottom: "20px"}}>
                    Contact
                </Typography>
                <Box sx={{ display:"block", marginBottom: "20px"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "block"}}>
                        Address: 
                    </Typography>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "block"}}>
                        Complexul Studen??esc, Timi??oara, 
                    </Typography>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        Aleea Studen??ilor nr. 19C - 22C
                    </Typography>
                    <Link href="http://maps.google.com/?q=Complexul Studen??esc, Timi??oara, Aleea Studen??ilor nr. 19C - 22C" underline="none" color="white">
                        <LocationOnIcon sx={{marginLeft: "10px", position:"relative", top: "5px", color: "white"}}/>
                    </Link>
                </Box>
                <Box sx={{ display:"block", marginBottom: "20px"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "block"}}>
                        Mail: 
                    </Typography>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        davidfilimon2000@yahoo.com
                    </Typography>
                    <Link href="mailto:davidfilimon2000@yahoo.com" underline="none" color="white">
                        <MailIcon sx={{marginLeft: "10px", position:"relative", top: "5px"}}/>
                    </Link>
                </Box>
                <Box sx={{ display:"block", marginBottom: "20px"}}>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "block"}}>
                        Phone: 
                    </Typography>
                    <Typography  variant="body1" component="div" sx={{fontWeight: "400", color: "white", display: "inline"}}>
                        (+40)771671635
                    </Typography>
                    <ContactPhoneIcon sx={{marginLeft: "10px", position:"relative", top: "5px", color: "white"}}/>
                </Box>
            </Box>
        </Box>
    );
}