import React, { useState, useEffect } from "react";
import CreateReservationDialog from "../CreateReservationDialog/CreateReservationDialog";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const Home = () => {
    const [reservations, setReservations] = useState([]);

    useEffect(() => {
        fetch("https://localhost:5001/api/reservations").then(response => response.json())
            .then(
                (result) => {
                    console.log(result)
                    setReservations(result);
                }
            )
    }, [])

    return (
        <div>
            <h2>Welcome to Sundown Boulevard</h2>
            <p>How can we help you?</p>
            <CreateReservationDialog/>

            <div>
                <TableContainer component={Paper}>
                    <Table aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Start</TableCell>
                                <TableCell align="right">End</TableCell>
                                <TableCell align="right">Number of people</TableCell>
                                <TableCell align="right">Selected meal</TableCell>
                                <TableCell align="right">Selected drink</TableCell>
                                <TableCell align="right">Guest name</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {
                                reservations.map(reservation =>
                                    <TableRow key={reservation.id}>
                                        <TableCell component="th" scope="row">
                                            {reservation.start}
                                        </TableCell>
                                        <TableCell align="right">
                                            {reservation.end}
                                        </TableCell>
                                        <TableCell align="right">
                                            {reservation.noOfPeople}
                                        </TableCell>
                                        <TableCell align="right">
                                            {reservation.selectedMeal}
                                        </TableCell>
                                        <TableCell align="right">
                                            {reservation.selectedDrink}
                                        </TableCell>
                                        <TableCell align="right">
                                            {`${reservation.user.firstName} ${reservation.user.lastName}`}
                                        </TableCell>
                                    </TableRow>
                                )
                            }
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
        </div>
    );
}

export default Home;