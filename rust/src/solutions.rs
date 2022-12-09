mod year_2022;

pub trait Solution {
    fn name(&self) -> &'static str;
    fn solve_part_one(&self, input: &str) -> i32;
    fn solve_part_two(&self, input: &str) -> i32;
}

pub fn get_solution(year: &u32, day: &u32) -> Result<&'static &'static dyn Solution, &'static str> {
    let aoc_year: &[&dyn Solution] = match year {
        2022 => &year_2022::ALL_SOLUTIONS,
        _ => return Err("Unsupported year for AOC Rust solutions"),
    };

    let solution = match aoc_year.get((day - 1) as usize) {
        Some(sln) => sln,
        None => return Err("Didn't find an AOC Rust solution"),
    };

    Ok(solution)
}
