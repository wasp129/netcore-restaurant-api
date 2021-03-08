import React, {useState} from 'react';
import "./reservation.scss";
import {useHistory} from "react-router-dom";
import {useParams} from "react-router";
import {addHours} from 'date-fns'
import {makeStyles} from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import Select from '@material-ui/core/Select';
import {Button} from "@material-ui/core";


const useStyles = makeStyles((theme) => ({
    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
}));

const Reservation = () => {
    const classes = useStyles();
    const [noOfPeople, setNoOfPeople] = useState();
    const [date, setDate] = useState();
    const [meal, setMeal] = useState();
    const [drink, setDrink] = useState();
    const {userId} = useParams();
    const history = useHistory();

    const handlePeopleChange = (event) => {
        setNoOfPeople(event.target.value);
    };

    const handleDateChange = (event) => {
        setDate(event.target.value);
    }

    const handleMealChange = (event) => {
        setMeal(event.target.value);
    }

    const handleDrinkChange = (event) => {
        setDrink(event.target.value);
    }

    const makeReservation = async () => {
        const end = addHours(new Date(date), 2);

        const data = {
            selectedMeal: meal,
            selectedDrink: drink,
            noOfPeople: noOfPeople,
            start: date,
            end: end,
            userId: userId
        }

        const response = await fetch("https://localhost:5001/api/reservations", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const content = await response.json();

        if (content) {
            history.push("/")
        }
    }

    return (
        <div className="reservation">
            <h2>Please enter the details of your visit</h2>
            <div className="input">
                <InputLabel>Number of people</InputLabel>
                <Select value={noOfPeople} onChange={handlePeopleChange}>
                    <MenuItem value={1}>1</MenuItem>
                    <MenuItem value={2}>2</MenuItem>
                    <MenuItem value={3}>3</MenuItem>
                    <MenuItem value={4}>4</MenuItem>
                    <MenuItem value={5}>5</MenuItem>
                    <MenuItem value={6}>8</MenuItem>
                    <MenuItem value={7}>9</MenuItem>
                    <MenuItem value={8}>10</MenuItem>
                </Select>
            </div>
            <div className="input">
                <TextField
                    id="datetime-local"
                    label="Selected time"
                    type="datetime-local"
                    defaultValue="2021-03-07T10:30"
                    value={date}
                    onChange={handleDateChange}
                    InputLabelProps={{
                        shrink: true,
                    }}
                />
            </div>
            <div className="input">
                <InputLabel>Meal</InputLabel>
                <Select value={meal} onChange={handleMealChange}>
                    <MenuItem value={"Burger"}>Burger</MenuItem>
                    <MenuItem value={"Pizza"}>Pizza</MenuItem>
                    <MenuItem value={"Pasta"}>Pasta</MenuItem>
                </Select>
            </div>
            <div className="input">
                <InputLabel>Drink</InputLabel>
                <Select value={drink} onChange={handleDrinkChange}>
                    <MenuItem value={"Soda"}>Soda</MenuItem>
                    <MenuItem value={"Beer"}>Beer</MenuItem>
                    <MenuItem value={"Water"}>Water</MenuItem>
                </Select>
            </div>

            <Button variant="contained" color="primary" onClick={makeReservation}>Make reservation</Button>
        </div>
    );
}

export default Reservation;