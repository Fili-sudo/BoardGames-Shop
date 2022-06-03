import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import SendIcon from '@mui/icons-material/Send';
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { createTheme, ThemeProvider } from '@mui/material/styles';
import emailjs from '@emailjs/browser';


const theme = createTheme({
    palette: {
      neutral: {
        main: '#36454F',
      },
    },
});


export default function FeedBackForm(){

    const {
        register,
        handleSubmit,
        reset,
        formState: { errors }
      } = useForm();

      const onSubmit = (data, e) => {
        console.log(data);
        emailjs.send("service_4l3b4ac","template_jfzqohd",{
            from_name: data.name,
            message: data.feedback,
            },"zI5ZlpxucEnkj2bmE")
        .then(res => {
            console.log('SUCCESS!', res.status, res.text);
            e.target.reset();
        })
        .catch(error => {
            alert("something went wrong");
        });
      };
      return(
        <Box
            component="form"
            autoComplete="off"
            onSubmit={handleSubmit(onSubmit)}
        >
        <ThemeProvider theme={theme}>
            <TextField
              id="name"
              {...register("name", { required: true })}
              label="Your Name"
              color='neutral'
              required
              sx={{marginBottom: "20px"}}
            />
            <TextField
              id="feedback"
              {...register("feedback", { required: true })}
              label="Feedback"
              color='neutral'
              multiline
              fullWidth
              required
              rows={7}
              sx={{marginBottom: "20px"}}
            />
        </ThemeProvider>
        <Button type='submit' color='secondary' variant="contained" endIcon={<SendIcon />}>
            Send
        </Button>
        </Box>
      );
}
