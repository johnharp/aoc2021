#lang racket
(require "state.rkt")
(provide valid-moves-from
         is-move-blocked
         from-val
         to-val
         num-steps)
#|
+-------------------------------------------+
| 0   1   2   3   4   5   6   7   8   9  10 |
+-----+  11   |  13   |  15   |  17   +-----+
      |  12   |  14   |  16   |  18   |
      +-------------------------------+

A move is a list of positions with the starting index first, the ending index first
therefore the start position is (first move)
end position is (last move)
number of steps to get from start to end is length - 1

|#

(define (from-val move)
  (first move))

(define (to-val move)
  (last move))

(define (num-steps move)
  (sub1 (length move)))

(define (moves-from-14)
  '((14 13 4 3 2 11 12)
    (14 13 4 3 2 11)
    (14 13)
    (14 13 4 5 6 15 16)
    (14 13 4 5 6 15)
    (14 13 4 5 6 7 8 17 18)
    (14 13 4 5 6 7 8 17)
    (14 13 4 3 2 1 0)
    (14 13 4 3 2 1)
    (14 13 4 3)
    (14 13 4 5)
    (14 13 4 5 6 7)
    (14 13 4 5 6 7 8 9)
    (14 13 4 5 6 7 8 9 10)))

(define (moves-from-13)
  '((13 4 3 2 11 12)
    (13 4 3 2 11)
    (13 14)
    (13 4 5 6 15 16)
    (13 4 5 6 15)
    (13 4 5 6 7 8 17 18)
    (13 4 5 6 7 8 17)
    (13 4 3 2 1 0)
    (13 4 3 2 1)
    (13 4 3)
    (13 4 5)
    (13 4 5 6 7)
    (13 4 5 6 7 8 9)
    (13 4 5 6 7 8 9 10)))

(define (moves-from-12)
  '((12 11)
    (12 11 2 3 4 13 14)
    (12 11 2 3 4 13)
    (12 11 2 3 4 5 6 15 16)
    (12 11 2 3 4 5 6 15)
    (12 11 2 3 4 5 6 7 8 17 18)
    (12 11 2 3 4 5 6 7 8 17)
    (12 11 2 1 0)
    (12 11 2 1)
    (12 11 2 3)
    (12 11 2 3 4 5)
    (12 11 2 3 4 5 6 7)
    (12 11 2 3 4 5 6 7 8 9)
    (12 11 2 3 4 5 6 7 8 9 10)))

(define (moves-from-11)
  '((11 12)
    (11 2 3 4 13 14)
    (11 2 3 4 13)
    (11 2 3 4 5 6 15 16)
    (11 2 3 4 5 6 15)
    (11 2 3 4 5 6 7 8 17 18)
    (11 2 3 4 5 6 7 8 17)
    (11 2 1 0)
    (11 2 1)
    (11 2 3)
    (11 2 3 4 5)
    (11 2 3 4 5 6 7)
    (11 2 3 4 5 6 7 8 9)
    (11 2 3 4 5 6 7 8 9 10)))

(define (moves-from-10)
  '((10 9 8 7 6 5 4 3 2 11 12)
    (10 9 8 7 6 5 4 3 2 11)
    (10 9 8 7 6 5 4 13 14)
    (10 9 8 7 6 5 4 13)
    (10 9 8 7 6 15 16)
    (10 9 8 7 6 15)
    (10 9 8 17 18)
    (10 9 8 17)
    (10 9 8 7 6 5 4 3 2 1 0)
    (10 9 8 7 6 5 4 3 2 1)
    (10 9 8 7 6 5 4 3)
    (10 9 8 7 6 5)
    (10 9 8 7)
    (10 9)))

(define (moves-from-9)
  '((9 8 7 6 5 4 3 2 11 12)
    (9 8 7 6 5 4 3 2 11)
    (9 8 7 6 5 4 13 14)
    (9 8 7 6 5 4 13)
    (9 8 7 6 15 16)
    (9 8 7 6 15)
    (9 8 17 18)
    (9 8 17)
    (9 8 7 6 5 4 3 2 1 0)
    (9 8 7 6 5 4 3 2 1)
    (9 8 7 6 5 4 3)
    (9 8 7 6 5)
    (9 8 7)
    (9 10)))

(define (moves-from-7)
  '((7 6 5 4 3 2 11 12)
    (7 6 5 4 3 2 11)
    (7 6 5 4 13 14)
    (7 6 5 4 13)
    (7 6 15 16)
    (7 6 15)
    (7 8 17 18)
    (7 8 17)
    (7 6 5 4 3 2 1 0)
    (7 6 5 4 3 2 1)
    (7 6 5 4 3)
    (7 6 5)
    (7 8 9)
    (7 8 9 10)))

(define (moves-from-5)
  '((5 4 3 2 11 12)
    (5 4 3 2 11)
    (5 4 13 14)
    (5 4 13)
    (5 6 15 16)
    (5 6 15)
    (5 6 7 8 17 18)
    (5 6 7 8 17)
    (5 4 3 2 1 0)
    (5 4 3 2 1)
    (5 4 3)
    (5 6 7)
    (5 6 7 8 9)
    (5 6 7 8 9 10)))

(define (moves-from-3)
  '((3 2 11 12)
    (3 2 11)
    (3 4 13 14)
    (3 4 13)
    (3 4 5 6 15 16)
    (3 4 5 6 15)
    (3 4 5 6 7 8 17 18)
    (3 4 5 6 7 8 17)
    (3 2 1 0)
    (3 2 1)
    (3 4 5)
    (3 4 5 6 7)
    (3 4 5 6 7 8 9)
    (3 4 5 6 7 8 9 10)
    ))

(define (moves-from-1)
  '((1 2 11 12)
    (1 2 11)
    (1 2 3 4 13 14)
    (1 2 3 4 13)
    (1 2 3 4 5 6 15 16)
    (1 2 3 4 5 6 15)
    (1 2 3 4 5 6 7 8 17 18)
    (1 2 3 4 5 6 7 8 17)
    (1 0)
    (1 2 3)
    (1 2 3 4 5)
    (1 2 3 4 5 6 7)
    (1 2 3 4 5 6 7 8 9)
    (1 2 3 4 5 6 7 8 9 10)))

(define (moves-from-0)
  '((0 1 2 11 12)
    (0 1 2 11)
    (0 1 2 3 4 13 14)
    (0 1 2 3 4 13)      
    (0 1 2 3 4 5 6 15 16)
    (0 1 2 3 4 5 6 15)
    (0 1 2 3 4 5 6 7 8 17 18)
    (0 1 2 3 4 5 6 7 8 17)
    (0 1)
    (0 1 2 3)
    (0 1 2 3 4 5)
    (0 1 2 3 4 5 6 7)
    (0 1 2 3 4 5 6 7 8 9)
    (0 1 2 3 4 5 6 7 8 9 10)))

(define (moves-from n)
  (case n
    [(0) (moves-from-0)]
    [(1) (moves-from-1)]
    [(2) '()]
    [(3) (moves-from-3)]
    [(4) '()]
    [(5) (moves-from-5)]
    [(6) '()]
    [(7) (moves-from-7)]
    [(8) '()]
    [(9) (moves-from-9)]
    [(10) (moves-from-10)]
    [(11) (moves-from-11)]
    [(12) (moves-from-12)]
    [(13) (moves-from-13)]
    [(14) (moves-from-14)]))


;(define (is-move-blocked state move)
;  (let* ([check-occupied (curry is-occupied state)]
;         [blocked-spots (filter check-occupied move)])
;    (> 0 (length blocked-spots))))

(define (is-move-blocked state move)
  (let* ([check-occupied (curry is-occupied state)]
         [blocked-spots (filter check-occupied (cdr move))])
    (> (length blocked-spots) 0)))

(define (is-move-including-locs move locs)
  (> (length (set-intersect move locs)) 0))


(define (is-valid-move state move)
  (and (not (is-move-blocked state move))))

(define (valid-moves-from state n)
  (filter (curry is-valid-move state) (moves-from n)))