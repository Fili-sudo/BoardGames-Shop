import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function SelectFilled(props) {
  const [order, setOrder] = React.useState('');

  const handleChange = (event) => {
    setOrder(event.target.value);
    props.orderRule(event.target.value);
  };

  return (
    <div>
      <FormControl variant="filled" sx={{ m: 1, minWidth: 120 }}>
        <InputLabel id="demo-simple-select-filled-label">Order</InputLabel>
        <Select
          labelId="demo-simple-select-filled-label"
          id="demo-simple-select-filled"
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
    </div>
  );
}
