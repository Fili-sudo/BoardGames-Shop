import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import API from '../api';

export default function StateSelectComponent(props){

const [order, setOrder] = React.useState(props.order);
const [value, setValue] = React.useState(props.order.state);

const handleChange = (event) => {
    setValue(event.target.value);
    console.log(event.target.value);
    API.put(`Orders/${order.id}`,{
        price: order.price,
        shippingAddress: order.shippingAddress,
        state: event.target.value
    }).then(res => {
        console.log(res);
        console.log(res.data)
    })
    //props.handleOrderStateChange(order.id);
  };


  return (
      <FormControl sx={{width: 160}} size="small">
        <InputLabel id="demo-simple-select-label">State</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={value}
          label="State"
          onChange={handleChange}
          onClick={(event) => event.stopPropagation()}
        >
          <MenuItem value={0}>In Processing</MenuItem>
          <MenuItem value={1}>Pending</MenuItem>
          <MenuItem value={2}>Confirmed</MenuItem>
          <MenuItem value={3}>Canceled</MenuItem>
          <MenuItem value={4}>Arrived</MenuItem>
        </Select>
      </FormControl>
  );
}

    