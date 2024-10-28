import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import Loader from "../common/Loader";
import Error from "../common/Error";
import { useQuery } from "@tanstack/react-query";
import { getCakeByName } from '../../services/apiCakes';
import { useNavigate } from "react-router-dom";
import CategorySelector from './CategorySelector';


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
	});
    console.log(cake);	
	if (isLoading) return <Loader />;
	if (error) return <Error />;

	const handleCategoryChange = (event) => {
		const selectedCategoryId = event.target.value; 
		navigate(`/cakes/${selectedCategoryId}`); 
	};

	return (
		<form onSubmit={handleSubmit(onSubmit)}>
			<div className={styledContainer}>
        <CategorySelector register={register} OnCategoryChange={handleCategoryChange}/>
			</div>
		</form>
	);
}
const styledInput = "border border-red-200 text-basic w-1/2 px-4 py-3 text-sm placeholder:text-stone-400 rounded-md  transition-all duration-300 focus:outline-none focus:ring focus:ring-pink focus:ring-opacity-50";
const styledContainer = "mx-[80px] mt-16 h-17 focus:outline-none flex justify-between items-center p-4 gap-50 ";


export default SearchBar

