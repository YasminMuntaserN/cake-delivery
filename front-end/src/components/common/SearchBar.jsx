import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import Loader from "../common/Loader";
import Error from "../common/Error";
import { useQuery } from "@tanstack/react-query";
import { getCakeByName } from '../../services/apiCakes';
import { useNavigate } from "react-router-dom";
import { HiCake } from "react-icons/hi2";
function SearchBar() {
	const navigate = useNavigate();
	const { register, handleSubmit } = useForm();
	const [cakeName, setCakeName] = useState(''); 

	const onSubmit = (data, event) => {
		event.preventDefault();
		setCakeName(data.cakeName);
		navigate(`/cakes/${data.categoryId}`);
	}

	const { data: cake, error, isLoading } = useQuery({
		queryKey: ['cakes', cakeName],
		queryFn: () => getCakeByName(cakeName),
		enabled: !!cakeName, 
	});

	const handleCategoryChange = (event) => {
		const selectedCategoryId = event.target.value; // Get the selected category ID
		navigate(`/cakes/${selectedCategoryId}`); // Navigate based on the selected category
	};

	return (
		<form onSubmit={handleSubmit(onSubmit)}>
			<div className={styledContainer}>
				<input
					{...register('cakeName')}
					type="text"
					placeholder="Search for cakes..."
					className={styledInput}
				/>
				<i><HiCake className="ml-[-210px] text-basic text-2xl"/></i>
				<select className={styledSelect} {...register("categoryId")} onChange={handleCategoryChange }>
					<option value="-1">All</option>
					<option value="2">Baby Shower</option>
					<option value="3">Anniversary</option>
					<option value="4">Birthday</option>
					<option value="5">Graduation</option>
					<option value="6">Wedding</option>

				</select>
			</div>
		</form>
	);
}
const styledInput = "border border-red-200 text-basic w-1/2 px-4 py-3 text-sm placeholder:text-stone-400 rounded-md  transition-all duration-300 focus:outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
const styledContainer = "mx-[80px] mt-16 h-17 focus:outline-none flex justify-between items-center p-4 gap-50 ";
const styledSelect = "border border-red-200 text-basic  w-[300px] px-4 py-2 text-sm rounded-md  transition-all duration-300 focus:outline-none focus:ring focus:ring-pink focus:ring-opacity-50";

export default SearchBar

