
import * as React from 'react';
import Pagination from '@mui/material/Pagination';
import Stack from '@mui/material/Stack';
import { useEffect, useState } from "react";

export default function BasicPagination({ productsPerPage, totalProducts, paginate}) {

  const pageNumbers = [];

  for (let i = 1; i <= Math.ceil(totalProducts / productsPerPage); i++) {
    pageNumbers.push(i);
  }
  //const [page, setPage] = useState(1);
  const handleChange = (event, value) => {
    //setPage(value);
    paginate(value);
  };

  return (
    <Stack spacing={2}>
      <Pagination count={pageNumbers.length} color="primary" onChange={handleChange}/>
    </Stack>
  );
}

