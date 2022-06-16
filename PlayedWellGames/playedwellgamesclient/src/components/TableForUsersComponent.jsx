import * as React from 'react';
import PropTypes from 'prop-types';
import { alpha } from '@mui/material/styles';
import { useNavigate } from "react-router-dom";
import Box from '@mui/material/Box';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import TableSortLabel from '@mui/material/TableSortLabel';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Checkbox from '@mui/material/Checkbox';
import IconButton from '@mui/material/IconButton';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import UpdateIcon from '@mui/icons-material/Update';
import Tooltip from '@mui/material/Tooltip';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
import DeleteIcon from '@mui/icons-material/Delete';
import FilterListIcon from '@mui/icons-material/FilterList';
import { visuallyHidden } from '@mui/utils';
import API from '../api';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import StateSelectComponent from './StateSelectComponent'
import InfoIcon from '@mui/icons-material/Info';


function descendingComparator(a, b, orderBy) {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
}

function getComparator(order, orderBy) {
  return order === 'desc'
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
}

// This method is created for cross-browser compatibility, if you don't
// need to support IE11, you can use Array.prototype.sort() directly
function stableSort(array, comparator) {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) {
      return order;
    }
    return a[1] - b[1];
  });
  return stabilizedThis.map((el) => el[0]);
}

//const headCells = [
//  {
//    id: 'name',
//    numeric: false,
//    disablePadding: true,
//    label: 'Dessert (100g serving)',
//  },
//  {
//    id: 'calories',
//    numeric: true,
//    disablePadding: false,
//    label: 'Calories',
//  },
//  {
//    id: 'fat',
//    numeric: true,
//    disablePadding: false,
//    label: 'Fat (g)',
//  },
//  {
//    id: 'carbs',
//    numeric: true,
//    disablePadding: false,
//    label: 'Carbs (g)',
//  },
//  {
//    id: 'protein',
//    numeric: true,
//    disablePadding: false,
//    label: 'Protein (g)',
//  },
//];
const ProductHeadCells = [
  {
    id: 'index',
    numeric: true,
    disablePadding: true,
    label: 'Index',
  },
  {
    id: 'username',
    numeric: false,
    disablePadding: false,
    label: 'Username',
  },
  {
    id: 'mail',
    numeric: false,
    disablePadding: false,
    label: 'Mail',
  },
  {
    id: 'firstName',
    numeric: false,
    disablePadding: false,
    label: 'First Name',
  },
  {
    id: 'lastName',
    numeric: false,
    disablePadding: false,
    label: 'Last Name',
  },
  {
    id: 'phone',
    numeric: false,
    disablePadding: false,
    label: 'Phone',
  },
  {
    id: 'address',
    numeric: false,
    disablePadding: false,
    label: 'Address',
  },
  {
    id: 'role',
    numeric: false,
    disablePadding: false,
    label: 'Role',
  },
]

function EnhancedTableHead(props) {
  const { onSelectAllClick, order, orderBy, numSelected, rowCount, onRequestSort } =
    props;
  const createSortHandler = (property) => (event) => {
    onRequestSort(event, property);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell padding="checkbox">
            {/* 'aria-label': 'select all products' */}
          <Checkbox
            color="primary"
            indeterminate={numSelected > 0 && numSelected < rowCount}
            checked={rowCount > 0 && numSelected === rowCount}
            onChange={onSelectAllClick}
            inputProps={{
              'aria-label': 'select all products', 
            }}
          />
        </TableCell>
        {ProductHeadCells.map((ProductHeadCell) => (
          <TableCell
            key={ProductHeadCell.id}
            align={(ProductHeadCell.numeric && ProductHeadCell.label!="Index") ? 'right' : 'left'}
            padding={ProductHeadCell.disablePadding ? 'none' : 'normal'}
            sortDirection={orderBy === ProductHeadCell.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === ProductHeadCell.id}
              direction={orderBy === ProductHeadCell.id ? order : 'asc'}
              onClick={createSortHandler(ProductHeadCell.id)}
            >
              {ProductHeadCell.label}
              {orderBy === ProductHeadCell.id ? (
                <Box component="span" sx={visuallyHidden}>
                  {order === 'desc' ? 'sorted descending' : 'sorted ascending'}
                </Box>
              ) : null}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}

EnhancedTableHead.propTypes = {
  numSelected: PropTypes.number.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  onSelectAllClick: PropTypes.func.isRequired,
  order: PropTypes.oneOf(['asc', 'desc']).isRequired,
  orderBy: PropTypes.string.isRequired,
  rowCount: PropTypes.number.isRequired,
};

const EnhancedTableToolbar = (props) => {
  const  numSelected  = props.numSelected;

  const navigate = useNavigate();

  const deleteSelected = () => {
    props.handleDeletion();
  }

  return (
    <Toolbar
      sx={{
        pl: { sm: 2 },
        pr: { xs: 1, sm: 1 },
        ...(numSelected > 0 && {
          bgcolor: (theme) =>
            alpha(theme.palette.primary.main, theme.palette.action.activatedOpacity),
        }),
      }}
    >
      {numSelected > 0 ? (
        <Typography
          sx={{ flex: '1 1 100%' }}
          color="inherit"
          variant="subtitle1"
          component="div"
        >
          {numSelected} selected
        </Typography>
      ) : (
        <Typography
          sx={{ flex: '1 1 100%' }}
          variant="h6"
          id="tableTitle"
          component="div"
        >
          Orders
        </Typography>
      )}

      {numSelected > 0 ? (
        <Tooltip title="Delete">
          <IconButton onClick={(event) => deleteSelected()}>
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      ) : (
        <> </>
      )}
    </Toolbar>
  );
};

EnhancedTableToolbar.propTypes = {
  numSelected: PropTypes.number.isRequired,
};



export default function EnhancedTable() {
  const [order, setOrder] = React.useState('asc'); 
  const [orderBy, setOrderBy] = React.useState('index'); //id
  const [selected, setSelected] = React.useState([]);
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [rerender, setRerender] = React.useState(false);

  const [rows, setRows] = React.useState([]);

  React.useEffect(() => {
    const fetchProducts = async () => {
        const res = await API.get('Authenticate/users');
        setRows(res.data);
      };
  
      fetchProducts();
  },[rerender]);

  const handleDeletion = () => {
    const auth = JSON.parse(localStorage.getItem('auth'));
    const token = auth.token;
    var newRows = rows.slice();
    selected.forEach((e) => {
        if(rows[e].username!="david_admin"){
            newRows.splice(e,1);
            API.delete(`Authenticate/users/${rows[e].id}`,{ headers: {
              Authorization: `Bearer ${token}`
            }}).then(res => {
              console.log(res);
              setRerender(!rerender);
            }).catch(error => {
              alert(`${rows[e].username} has orders and can't be deleted`);
              setRerender(!rerender);
            });
            
            
        }
        else{
            alert("you can't delete this user");
        }
        
    });
    setRows(newRows);
    setSelected([]);
  }
  const getRole = (data) =>{
      if(data == 0){
          return "customer";
      }
      return "admin";
  }


  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === 'asc';
    setOrder(isAsc ? 'desc' : 'asc');
    setOrderBy(property);
  };

  const handleSelectAllClick = (event) => {
    if (event.target.checked) {
      const newSelecteds = rows.map((n, index) => index);
      console.log(newSelecteds.length);
      setSelected(newSelecteds);
      return;
    }
    setSelected([]);
  };

  const handleClick = (event, name) => {
    const selectedIndex = selected.indexOf(name);
    let newSelected = [];

    if (selectedIndex === -1) {
      newSelected = newSelected.concat(selected, name);
    } else if (selectedIndex === 0) {
      newSelected = newSelected.concat(selected.slice(1));
    } else if (selectedIndex === selected.length - 1) {
      newSelected = newSelected.concat(selected.slice(0, -1));
    } else if (selectedIndex > 0) {
      newSelected = newSelected.concat(
        selected.slice(0, selectedIndex),
        selected.slice(selectedIndex + 1),
      );
    }

    setSelected(newSelected);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };


  const isSelected = (name) => selected.indexOf(name) !== -1;

  // Avoid a layout jump when reaching the last page with empty rows.
  const emptyRows =
    page > 0 ? Math.max(0, (1 + page) * rowsPerPage - rows.length) : 0; 

  return (
    <Box sx={{ width: '100%' }}>
      <Paper sx={{ width: '100%', mb: 2 }}>
        <EnhancedTableToolbar numSelected={selected.length}  selected={selected} handleDeletion={handleDeletion}/>
        <TableContainer>
          <Table
            sx={{ minWidth: 750 }}
            aria-labelledby="tableTitle"
            size={'medium'} 
          >
            <EnhancedTableHead
              numSelected={selected.length}
              order={order}
              orderBy={orderBy}
              onSelectAllClick={handleSelectAllClick}
              onRequestSort={handleRequestSort}
              rowCount={rows.length}
            />
            <TableBody>
              {/* if you don't need to support IE11, you can replace the `stableSort` call with:
                 rows.slice().sort(getComparator(order, orderBy)) */}
              {stableSort(rows, getComparator(order, orderBy))
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row, index) => {
                  const correctIndex = (page)*rowsPerPage+index;
                  const isItemSelected = isSelected(correctIndex);
                  const labelId = `enhanced-table-checkbox-${correctIndex}`;

                  return (
                    <TableRow
                      hover
                      onClick={(event) => handleClick(event, correctIndex)}
                      role="checkbox"
                      aria-checked={isItemSelected}
                      tabIndex={-1}
                      key={correctIndex}
                      selected={isItemSelected}
                    >
                      <TableCell padding="checkbox">
                        <Checkbox
                          color="primary"
                          checked={isItemSelected}
                          inputProps={{
                            'aria-labelledby': labelId,
                          }}
                        />
                      </TableCell>
                      <TableCell
                        component="th"
                        id={labelId}
                        scope="row"
                        padding="none"
                      >
                        {correctIndex + 1}
                      </TableCell>
                       {/* add more table cells and rename them with your names */}
                      <TableCell align="left">{row.username}</TableCell>
                      <TableCell align="left">{row.email}</TableCell>
                      <TableCell align="left">{row.firstName} </TableCell>
                      <TableCell align="left">{row.lastName}</TableCell> 
                      <TableCell align="left">{row.phone}</TableCell>
                      <TableCell align="left">{row.address} </TableCell>
                      <TableCell align="left">{getRole(row.role)} </TableCell>
                      
                    </TableRow>
                  );
                })}
              {emptyRows > 0 && (
                <TableRow
                  style={{
                    height: (53) * emptyRows,
                  }}
                >
                  <TableCell colSpan={6} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component="div"
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </Box>
  );
}
