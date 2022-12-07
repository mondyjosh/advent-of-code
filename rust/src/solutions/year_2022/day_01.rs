use crate::solutions::Solution;

pub struct Day01;

impl Solution for Day01 {
    fn name(&self) -> &'static str {
        "Calorie Counting"
    }

    fn solve_part_1(&self, input: &str) -> i32 {
        let lines: Vec<&str> = input.lines().collect();

        for line in &lines {
            println!("{}", line);
        }

        dbg!(lines.len());
        lines.len() as i32
    }

    fn solve_part_2(&self, input: &str) -> i32 {
        input.len() as i32
    }
}
