import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import Box from '@mui/material/Box';

export default function SelectFilled(props) {
  const [order, setOrder] = React.useState('');
  const [noOfItems, SetnoOfItems] = React.useState(8);

  const handleChange = (event) => {
    setOrder(event.target.value);
    props.orderRule(event.target.value);
  };
  const handleChangeOfItems = (event) => {
    SetnoOfItems(event.target.value);
    props.itemsOnPage(event.target.value);
  };

  return (
    <div>
      <Box sx={{ display:"flex", justifyContent:"left", margin: "0 0 0 5%"}}>
      <FormControl variant="filled" sx={{ m: 1, minWidth: 120}}>
        <InputLabel id="demo-simple-select-filled-label2">Items on page</InputLabel>
        <Select
          labelId="demo-simple-select-filled-label2"
          id="demo-simple-select-filled2"
          value={noOfItems}
          onChange={handleChangeOfItems}
        >
          <MenuItem value={1}>1</MenuItem>
          <MenuItem value={4}>4</MenuItem>
          <MenuItem value={8}>8</MenuItem>
          <MenuItem value={12}>12</MenuItem>
          <MenuItem value={16}>16</MenuItem>
          <MenuItem value={20}>20</MenuItem>
        </Select>
      </FormControl>
      <FormControl variant="filled" sx={{ m: 1, minWidth: 120 }}>
        <InputLabel id="demo-simple-select-filled-label1">Order</InputLabel>
        <Select
          labelId="demo-simple-select-filled-label1"
          id="demo-simple-select-filled1"
          value={order}
          onChange={handleChange}
        >
          <MenuItem value="">
            <em>None</em>
          </MenuItem>
          <MenuItem value={"By price"}>By price</MenuItem>
          <MenuItem value={"Alphabetically"}>Alphabetically</MenuItem>
        </Select>
      </FormControl>
      </Box>
    </div>
  );
}
